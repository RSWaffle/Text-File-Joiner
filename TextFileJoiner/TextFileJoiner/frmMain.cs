
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
            numberLabel.Text = "Number of files to be converted: " +
                    handler.OpenFileHandler().ToString();

            if (numberLabel.Text != "Number of files to be converted: 0")
            {
                readyLabel.Text = "Ready to convert!";
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
            numberLabel.Text = "Number of files to be converted: " +
                                handler.OpenFileHandler().ToString();

            if (numberLabel.Text != "Number of files to be converted: 0")
            {
                readyLabel.Text = "Ready to convert!";
            }
        }
        /// <summary>
        /// This method converts the selected files into one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            handler.SaveFileHandler();
            handler.Convert();

            numberLabel.Text = "Number of files to be converted: 0";
            readyLabel.Text = "Waiting for files...";
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
    }
}