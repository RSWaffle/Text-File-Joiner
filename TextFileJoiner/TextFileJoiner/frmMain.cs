using System;
using System.Windows.Forms;

namespace TextFileJoiner
{
    public partial class frmMain : Form
    {
        private FileHandler handler = new FileHandler();

        public frmMain()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            numberLabel.Text = "Number of files to be converted: " +
                                handler.OpenFileHandler().ToString();

            if (numberLabel.Text != "Number of files to be converted: 0")
            {
                readyLabel.Text = "Ready to convert!";
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            handler.SaveFileHandler();
            handler.Convert();

            numberLabel.Text = "Number of files to be converted: 0";
            readyLabel.Text = "Waiting for files...";
        }
    }
}