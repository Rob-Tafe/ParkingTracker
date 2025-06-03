using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

// This allows us to use regex to ensure the correct format of the licence plates
using System.Text.RegularExpressions;

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
        List<string> mainLinesGlobal;

        // This is the list variable that will hold the data for the Lbtagged list box to
        // display.
        List<string> taggedLinesGlobal;

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

        } // End of BtnOpen method



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

        } // End of ReadLbMain method



        // Start of DisplayLbMain method. This method is responsible for displaying the data from the
        // mainLinesGlobal list variable, where most of our data handing will take place
        public void DisplayLbMain()
        {
            // Here we clear LbMain to keep things readable & user friendly
            LbMain.Items.Clear();

            // Here we add the content of mainLinesGlobal list that stores all of our data that was loaded
            // from the text file, and/or was added via user input.
            if (mainLinesGlobal != null && mainLinesGlobal.Any(line => Regex.IsMatch(line, @"^\d[A-Z]{3}-\d{3}$")))
            {
                mainLinesGlobal.Sort();

                foreach (string line in mainLinesGlobal)
                {
                    LbMain.Items.Add($"{mainLinesGlobal.IndexOf(line)}.      {(string.IsNullOrWhiteSpace(line) ? "-" : line)}");
                }
            }

        } // End of DisplayLbMain method



        // Start of BtnSave method. This method is responsible for writing the contents of mainLinesGlobal
        // to the selected save file.
        private void BtnSave_Click(object sender, EventArgs e)
        {
            TbFeedback.Clear();



            


        } // End of BtnSave method
        


        // Start of BtnAdd method. This method is responsiblef or adding a licence plate number from the TbInput
        // text box to the LbMain list box.
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TbFeedback.Clear();

            string addLpFromInput = TbInput.Text;

            if ((TbInput != null) && (Regex.IsMatch(addLpFromInput, @"^\d[A-Z]{3}-\d{3}$")))
            {
                string varTbInputAdd = TbInput.Text;
                TbFeedback.Text = $"varTbInputAdd = {varTbInputAdd}";

                    if (!mainLinesGlobal.Contains(varTbInputAdd))
                    {
                        mainLinesGlobal.Add(varTbInputAdd);
                        TbInput.Clear();
                        LbMain.Focus();
                        DisplayLbMain();
                    }
                    else
                    {
                        TbFeedback.Text = "Duplicate entry. Licence plate already entered.";
                        TbInput.Clear();
                    }

        } // End of BtnAdd method



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

            // Here we declare the variables that will allow the binary search to function properly
            int lowBound = 0;
            int highBound = mainLinesGlobal.Count - 1;
            string target = TbInput.Text;

            // This is the while loop that makes up the core function of the binary search method
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

        } // End of binary search method



        // Start of the InputFormatCheck method.This method is responsible for checking if the input value in the
        // TbInput textbox meets the format requirements of the program, and returns errors for various instances of
        // format non-complaince.
        public void InputFormatCheck()
        {
            string textCheck = TbInput.Text;

            // This first if statement ensures everythng is in place for the binary search to function without throwing
            // an error immediately
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

        } // End of InputFormatCheck method



        // Linear search method. This method will perform a linear search for the licence plate entered into
        // the TbInput textbox
        private void BtnLinear_Click(object sender, EventArgs e)
        {
            DisplayLbMain();


        } // End of Linear search method



    } // End of Parkingtraker : Form class



} // End of ParkingTracker namespace
