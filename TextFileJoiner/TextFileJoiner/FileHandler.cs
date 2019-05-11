using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TextFileJoiner
{
    internal class FileHandler
    {
        private List<string> fileNames;
        private string saveDestination = "";
        private int numberOfSpaces;
        private string spaces = "";

        public FileHandler()
        {
            fileNames = new List<string>();
            SetNumOfSpaces(1);
        }

        public void SetNumOfSpaces(int spaces)
        {
            numberOfSpaces = spaces;

            for (int i = 0; i < spaces; i++)
            {
                this.spaces += "\n";
            }
        }

        public void Convert()
        {
            string content = "";

            for (int i = 0; i < fileNames.Count; i++)
            {
                content += File.ReadAllText(fileNames[i]) + spaces;
            }

            File.AppendAllText(saveDestination, content);
        }

        /// <summary>
        /// Opens the open file dialog and stores the file path of the selected files.
        /// </summary>
        /// <returns>the number of files to be translated for the main window to use.</returns>
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
                int i = 0;
                foreach (String file in OpenDlg.FileNames)
                {
                    numberOfFiles++;
                    fileNames.Add(OpenDlg.FileNames[i]);
                    i++;
                }
            }
            return numberOfFiles;
        }

        /// <summary>
        /// Opens the save file dialog and gets the filepath of the file to be written.
        /// </summary>
        public void SaveFileHandler()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.InitialDirectory = Application.StartupPath;
            dlg.Title = "Save the text file";
            dlg.Filter = "text files|*.txt|all files|*.*";

            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            saveDestination = dlg.FileName;

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write));
                saveDestination = dlg.FileName;
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