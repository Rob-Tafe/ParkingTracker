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



        // Start of BtnOpen method
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openTxtFile = new OpenFileDialog();
            openTxtFile.Title = "Open Text file";
            openTxtFile.Filter = "TXT files|*.txt";
            openTxtFile.InitialDirectory = @"C:\Users\P214430\source\repos\ParkingTracker\ParkingTracker Text Files";

            if (openTxtFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openTxtFile.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            LbMain.Text = myStream.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        } // End of BtnOpen method



    } // End of Parkingtraker : Form class



} // End of ParkingTracker namespace
