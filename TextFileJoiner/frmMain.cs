﻿///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:        frmMain.cs
//	Description:       This class gathers all of the user input and works with the File Handler class to convert.
//
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University
//	Created:           Friday May 10, 2019
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Windows.Forms;

namespace TextFileJoiner
{
    public partial class frmMain : Form
    {
        private FileHandler handler = new FileHandler();

        /// <summary>
        /// basic no argument constructor.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method opens the open file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numberLabel.Text = "Number of files to be joined: " +
                    handler.OpenFileHandler().ToString();

            if (numberLabel.Text != "Number of files to be joined: 0")
            {
                readyLabel.Text = "Ready to join files!";
            }
        }

        /// <summary>
        /// This opens the about box that displays info about the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        /// <summary>
        /// This button executes the check for updates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This method opens the open file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            numberLabel.Text = "Number of files to be joined: " +
                                handler.OpenFileHandler().ToString();

            if (numberLabel.Text != "Number of files to be joined: 0")
            {
                readyLabel.Text = "Ready to join files!";
            }
        }

        /// <summary>
        /// This method converts the selected files into one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (handler.getNumFiles() == 0)
            {
                DialogResult dialogResult = MessageBox.Show("They're no files selected to be joined. Are you sure you want to write a blank file?", "Write a blank file?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    handler.SaveFileHandler();
                    handler.Convert();

                    numberLabel.Text = "Number of files to be joined: 0";
                    readyLabel.Text = "Waiting for files...";
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    handler.SaveFileHandler();
                    handler.Convert();

                    numberLabel.Text = "Number of files to be joined: 0";
                    readyLabel.Text = "Waiting for files...";
                }
            }
        }

        /// <summary>
        /// This will update the number of spaces in between each file in the end result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numSpaces_ValueChanged(object sender, EventArgs e)
        {
            handler.SetNumOfSpaces((int)numSpaces.Value);
        }

        /// <summary>
        /// This method checks to see if the tick box is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteFilesBox_CheckedChanged(object sender, EventArgs e)
        {
            if (deleteFilesBox.Checked)
            {
                handler.SetDeleteFiles(true);
            }
            else
            {
                handler.SetDeleteFiles(false);
            }
        }
    }
}