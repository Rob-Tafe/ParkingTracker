using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
// This allows us to use regex to ensure the correct format of the licence plates.
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;

namespace ParkingTracker
{



    public partial class ParkingTracker : Form
    {



        public ParkingTracker()
        {
            InitializeComponent();
        }



        // This is the list variable that will hold the data for the LbMain listbox
        // to display, as well as allow us to altar without having to commit to writing
        // to a text file with every button press.
        List<string> mainLinesGlobal = new List<string>();

        // This is the list variable that will hold the data for the Lbtagged list box to
        // display.
        List<string> taggedLinesGlobal = new List<string>();

        string nameOfSelectedTxtFile;


        bool globalIfcFault = false;



        // Start of BtnOpen method. This method is responsible for enabling the user to
        // open a text file that stored dada that can be used or modified by the other methods.
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            TbFeedback.Clear();

            OpenFileDialog openTxtFile = new OpenFileDialog();
            openTxtFile.Title = "Open Text file";
            openTxtFile.Filter = "TXT files|*.txt";
            openTxtFile.InitialDirectory = @"C:\Users\P214430\source\repos\ParkingTracker\ParkingTracker Text Files";

            if (openTxtFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReadLbMain(openTxtFile.FileName);
                    nameOfSelectedTxtFile = openTxtFile.FileName;
                    TbFeedback.Text = $"File = {nameOfSelectedTxtFile}";
                }
                catch
                {
                    TbFeedback.Text = "Error: Could not read file from disk.";
                }
            }

        } // End of BtnOpen method.



        // Start of ReadLbMain method. This method is responsible for reading the contents of the selected
        // text file.
        private void ReadLbMain(string filePath)
        {
            TbFeedback.Clear();

            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();

                mainLinesGlobal = lines;

                DisplayLbMain();
            }
            else
            {
                TbFeedback.Text = "The file was not found.";
            }

        } // End of ReadLbMain method.



        // Start of DisplayLbMain method. This method is responsible for displaying the data from the
        // mainLinesGlobal list variable, where most of our data handing will take place.
        public void DisplayLbMain()
        {
            // Here we clear LbMain to keep things readable & user friendly.
            LbMain.Items.Clear();

            // Here we add the content of mainLinesGlobal list that stores all of our data that was loaded
            // from the text file, and/or was added via user input.
            if (mainLinesGlobal != null && mainLinesGlobal.Any(line => Regex.IsMatch(line, @"^\d[A-Z]{3}-\d{3}$")))
            {
                mainLinesGlobal.Sort();

                foreach (string line in mainLinesGlobal)
                {
                    LbMain.Items.Add($"{line}");
                }
            }

            DisplayLbTagged();

        } // End of DisplayLbMain method.



        // Start of DisplayLbTagged method. This method is responsible for displaying the list of Tagged licence
        // plate numbers. It should update alongside LbMain (the DisplayLbMain method).
        public void DisplayLbTagged()
        {
            LbTagged.Items.Clear();

            if (taggedLinesGlobal != null && taggedLinesGlobal.Any(line => Regex.IsMatch(line, @"^\d[A-Z]{3}-\d{3}$")))
            {
                taggedLinesGlobal.Sort();

                foreach (string line in taggedLinesGlobal)
                {
                    LbTagged.Items.Add($"{line}");
                }
            }

        } // End of DisplayLbTagged method.



        // Start of BtnAdd method. This method is responsiblef or adding a licence plate number from the TbInput
        // text box to the LbMain list box.
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TbFeedback.Clear();

            InputFormatCheck();

            // This if statement allows the Linear search method to stop itself if the InputFormatCheck method
            // returns a formatting error when called. It then resets the global variable that controls the 
            // fault detection so that it can be resued.
            if (globalIfcFault == true)
            {
                globalIfcFault = false;
                return;
            }

            string varTbInputAdd = TbInput.Text;
            TbFeedback.Text = $"varTbInputAdd = {varTbInputAdd}";

            if (!mainLinesGlobal.Contains(varTbInputAdd))
            {
                mainLinesGlobal.Add(varTbInputAdd);
                TbInput.Clear();
                TbFeedback.Clear();
                LbMain.Focus();
                DisplayLbMain();
            }
            else
            {
                TbFeedback.Text = "Duplicate entry. Licence plate already entered.";
                TbInput.Clear();
                return;
            }

        } // End of BtnAdd method.



        // Binary search method. This method is responsible for performing a binary search of the LbMain listbox,
        // in order to find the licence plat that the user has inputted to the TbInput textbox.
        public void BtnBinary_Click(object sender, EventArgs e)
        {
            DisplayLbMain();

            InputFormatCheck();

            // This if statement allows the Binary search method to stop itself if the InputFormatCheck method
            // returns a formatting error when called. It then resets the global variable that controls the 
            // fault detection so that it can be resued.
            if (globalIfcFault == true)
            {
                globalIfcFault = false;
                return;
            }

            // Here we declare the variables that will allow the binary search to function properly.
            int lowBound = 0;
            int highBound = mainLinesGlobal.Count - 1;
            string target = TbInput.Text;

            // This is the while loop that makes up the core function of the binary search method.
            while ((lowBound <= highBound))
            {
                int mid = (lowBound + highBound) / 2;

                int compareStrings = String.Compare(mainLinesGlobal[mid], target, StringComparison.OrdinalIgnoreCase);


                if (compareStrings == 0)
                {
                    // Target found
                    TbFeedback.Text = $"{target} found at index {mid}";
                    LbMain.SetSelected(mid, true);
                    TbInput.Clear();
                    return;
                }
                else if (compareStrings > 0)
                {
                    highBound = mid - 1;
                }
                else
                {
                    lowBound = mid + 1;
                }

            }

            TbFeedback.Text = "Licence plate not found.";

        } // End of binary search method.



        // Start of the InputFormatCheck method.This method is responsible for checking if the input value in the
        // TbInput textbox meets the format requirements of the program, and returns errors for various instances of
        // format non-complaince.
        public void InputFormatCheck()
        {
            string textCheck = TbInput.Text;

            // This first if statement ensures everythng is in place for the binary search to function without throwing
            // an error immediately.
            if (mainLinesGlobal == null)
            {
                TbFeedback.Text = "Please load a file first.";
                TbInput.Clear();
                globalIfcFault = true;
                return;
            }
            else 
            if ((TbInput == null) || (!(Regex.IsMatch(textCheck, @"^\d[A-Z]{3}-\d{3}$"))))
            {
                TbFeedback.Text = "Invalid input, please input a Licence plate number in the format: #ABC-###.";
                TbInput.Clear();
                globalIfcFault = true;
                return;
            }

        } // End of InputFormatCheck method.



        // Linear search method. This method will perform a linear search for the licence plate entered into
        // the TbInput textbox.
        private void BtnLinear_Click(object sender, EventArgs e)
        {
            DisplayLbMain();

            TbFeedback.Clear();

            InputFormatCheck();

            // This if statement allows the Linear search method to stop itself if the InputFormatCheck method
            // returns a formatting error when called. It then resets the global variable that controls the 
            // fault detection so that it can be resued.
            if (globalIfcFault == true)
            {
                globalIfcFault = false;
                return;
            }

            string linearTarget = TbInput.Text;
            bool linearFound = false;

            for (int listIndexOfVal = 0; listIndexOfVal <= mainLinesGlobal.Count; listIndexOfVal++)
            {
                if ((!linearFound) && (listIndexOfVal >= mainLinesGlobal.Count))
                {
                    TbFeedback.Text = "Licence plate not found in the Main list.";
                    return;
                }
                else if (linearTarget == mainLinesGlobal[listIndexOfVal])
                {
                    TbFeedback.Text = $"{linearTarget} found at index {listIndexOfVal}";
                    linearFound = true;
                    LbMain.SetSelected(listIndexOfVal, true);
                    TbInput.Clear();
                    return;
                }
            }

        } // End of Linear search method.



        // This is the LbMainSelect method. It will add a licence plate that is clicked on in the LbMain
        // listbox to the TbInput textbox. This method will also display information about the currently
        // selected licence plate.
        private void LbMainSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(LbMain.GetItemText(LbMain.SelectedItem), @"^\d[A-Z]{3}-\d{3}$")))
            {
                TbFeedback.Clear();
                TbInput.Text = LbMain.GetItemText(LbMain.SelectedItem);
                LbTagged.ClearSelected();
                TbFeedback.Text = $"{LbMain.SelectedItem} currently selected.";
            }
            else if (!(Regex.IsMatch(LbMain.GetItemText(LbMain.SelectedItem), @"^\d[A-Z]{3}-\d{3}$")))
            {
                TbFeedback.Text = "No licence plate selected.";
                LbMain.ClearSelected();
                DisplayLbMain();
                return;
            }

        } // End of LbMainSelect method.



        // This is the BtnDelete method. It will delete a value that the user has selected from the LbMain listbox.
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string deleteVal = LbMain.GetItemText(LbMain.SelectedItem);

            mainLinesGlobal.Remove($"{deleteVal}");

            TbFeedback.Text = $"{deleteVal} deleted from the Main list.";

            DisplayLbMain();

        } // End of Delete (button) method.



        // This is the TaggedRemove_DoubleClick method. It allows a user to double click on a licence plate from the
        // LbTagged listbox to delete it.
        private void TaggedRemove_DoubleClick(object sender, EventArgs e)
        {
            string dcRemoveVal = LbTagged.GetItemText(LbTagged.SelectedItem);
            if (dcRemoveVal != null && (Regex.IsMatch(dcRemoveVal, @"^\d[A-Z]{3}-\d{3}$")))
            {
                mainLinesGlobal.Add(dcRemoveVal);

                taggedLinesGlobal.Remove($"{dcRemoveVal}");

                TbFeedback.Text = $"{dcRemoveVal} removed from the Tagged list and added to the Main list.";

                DisplayLbMain();
            }
            else
            {
                TbFeedback.Text = "Please double click on a Licence plate number to move it from the Tagged list to Main list.";
                return;
            }
            
        } // End of TaggedRemove_DoubleClick method



        // This is the Edit method. This method will be responsible for allowing a user to change
        // the selected item on the list to the value entered into the TbInput textbox.
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            InputFormatCheck();

            // This if statement allows the Edit method to stop itself if the InputFormatCheck method
            // returns a formatting error when called. It then resets the global variable that controls the 
            // fault detection so that it can be resued.
            if (globalIfcFault == true)
            {
                globalIfcFault = false;
                return;
            }

            string inputValue = TbInput.Text;

            if (LbMain.SelectedItem == null)
            {
                TbFeedback.Text = "Please select an entry in the Main list to edit.";
                return;
            }
            else if (mainLinesGlobal.Contains(inputValue))
            {
                TbFeedback.Text = "Duplicate entry. Licence plate already present in Main list.";
                TbInput.Clear();
                return;
            }
            else if (LbMain.SelectedIndex != -1 && LbMain.SelectedItem != null)
            {
                string selectedIndexInput = LbMain.SelectedItem.ToString();
                int indexInput = LbMain.FindString(selectedIndexInput);

                TbFeedback.Text = $"Licence plate {selectedIndexInput} has been edited to {inputValue}.";

                mainLinesGlobal[indexInput] = inputValue;

                TbInput.Clear();

                DisplayLbMain();
            }

        } // End of Edit method.



        // This is the Tag method. It allows a user to select a licence plate from the LbMain listbox and add it
        // to the LbTagged listbox.
        private void BtnTag_Click(object sender, EventArgs e)
        {

            TbFeedback.Clear();

            string selectedValToTag = LbMain.GetItemText(LbMain.SelectedItem);

            if (!(taggedLinesGlobal.Contains(selectedValToTag)) && (Regex.IsMatch(selectedValToTag, @"^\d[A-Z]{3}-\d{3}$")))
            {
                taggedLinesGlobal.Add(selectedValToTag);

                mainLinesGlobal.Remove(selectedValToTag);

                TbFeedback.Text = $"{selectedValToTag} moved to Tagged list.";
            }
            else if (!(Regex.IsMatch(selectedValToTag, @"^\d[A-Z]{3}-\d{3}$"))) 
            {
                TbFeedback.Text = "Please select a valid Licence plate to Tag.";
                return;
            }
            else
            {
                TbFeedback.Text = $"{selectedValToTag} is already present in the Tagged list.";
                return;
            }

            DisplayLbMain();
            
        } // End of Tag method.



        // This is the ShowSelectedValueInfo method. It is responsible for displaying information about the selected
        // licence plate in the TbFeedback textbox.
        private void ShowSelectedTaggedValueInfo(object sender, EventArgs e)
        {
            if ((Regex.IsMatch(LbTagged.GetItemText(LbTagged.SelectedItem), @"^\d[A-Z]{3}-\d{3}$")))
            {
                TbFeedback.Clear();
                TbInput.Text = LbTagged.GetItemText(LbTagged.SelectedItem);
                LbMain.ClearSelected();
                TbFeedback.Text = $"{LbTagged.SelectedItem} currently selected.";
            }
            else if (!(Regex.IsMatch(LbTagged.GetItemText(LbTagged.SelectedItem), @"^\d[A-Z]{3}-\d{3}$")))
            {
                TbFeedback.Text = "No licence plate selected.";
                LbTagged.ClearSelected();
                DisplayLbMain();
                return;
            }

        } // End of ShowSelectedTaggedValueInfo method.



        // This is the Reset button method. It will remove all data from both lists (mainLinesGlobal and 
        // taggedLinesGlobal) and clear all data from the list boxes.
        private void BtnReset_Click(object sender, EventArgs e)
        {
            TbFeedback.Clear();
            TbFeedback.Text = "Reset of data lists initiated.";

            
            if ((mainLinesGlobal.Count > 0) && (taggedLinesGlobal.Count > 0))
            {
                DialogResult resetConfirm = MessageBox.Show("Are you sure you wish to clear all data from the Main AND Tagged lists?",
                "Reset Confirmation", MessageBoxButtons.YesNo);

                if (resetConfirm == DialogResult.Yes)
                {
                    mainLinesGlobal = new List<string>();
                    taggedLinesGlobal = new List<string>();
                    TbInput.Clear();
                    DisplayLbMain();
                    TbFeedback.Text = "Reset complete. All data cleared.";
                }
                else if (resetConfirm == DialogResult.No)
                {
                    TbFeedback.Text = "Reset cancelled.";
                    return;
                }
            }
            else
            {
                TbFeedback.Text = "No data present.";
            }

        } // End of Reset button method.



    } // End of Parkingtraker : Form class.



} // End of ParkingTracker namespace.
