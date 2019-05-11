using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileJoiner
{
    public partial class frmMain : Form
    {

        FileHandler handler = new FileHandler();

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

            if(numberLabel.Text != "Number of files to be converted: 0")
            {
                readyLabel.Text = "Ready to convert!";
            }

        }

    }
}
