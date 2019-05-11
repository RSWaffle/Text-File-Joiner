using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileJoiner
{
    class FileHandler
    {

        public FileHandler()
        {

        }

        public static void Convert()
        {

        }

        public int OpenFileHandler()
        {
            int numberOfFiles = 0;

            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Filter = "text files|*.txt;*.text";
            OpenDlg.Multiselect = true;
            OpenDlg.InitialDirectory = Application.StartupPath;
            OpenDlg.Title = "Select text files you wish to combine.";


            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                foreach (String file in OpenDlg.FileNames)
                {
                    numberOfFiles++;
                }
            }
            return numberOfFiles;
        }

        public void saveFileHandler()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.InitialDirectory = Application.StartupPath;
            dlg.Title = "Save the text file";
            dlg.Filter = "text files|*.txt|all files|*.*";

            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write));

               // for (int i = 0; i < nameList.Count(); i++)
               // {
               //     writer.WriteLine(nameList.getName(i) + "#");
               // }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
