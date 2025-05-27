using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void DisplayLbMain()
        {
            TbFeedback.Clear();
            // Here we clear LbMain to keep things readable & user friendly
            LbMain.Items.Clear();

            // Here we add the content of mainLinesGlobal list that stores all of our data that was loaded
            // from the text file, and/or was added via user input.
            if (mainLinesGlobal != null)
            {
                foreach (string line in mainLinesGlobal)
                {
                    LbMain.Items.Add(string.IsNullOrWhiteSpace(line) ? "-" : line);
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

            if ((TbInput != null) && (TbInput.TextLength == 7))
            {
                string varTbInputAdd = TbInput.Text;
                TbFeedback.Text = $"varTbInputAdd = {varTbInputAdd}";

                if (mainLinesGlobal == null)
                {
                    TbFeedback.Text = "Please load a file before trying to add a Licence.";
                    return;
                }
                else
                {
                    if (!mainLinesGlobal.Contains(varTbInputAdd))
                    {
                        mainLinesGlobal.Add(varTbInputAdd);
                        TbInput.Clear();
                        DisplayLbMain();
                    }
                    else
                    {
                        TbFeedback.Text = "Duplicate entry. Licence plate already entered.";
                        TbInput.Clear();
                    }
                }

            }
            else
            {
                TbFeedback.Text = "Invalid input format, please input a 7 digit Licence plate number.";
                TbInput.Clear();
            }

        } // End of BtnAdd method



    } // End of Parkingtraker : Form class



} // End of ParkingTracker namespace
