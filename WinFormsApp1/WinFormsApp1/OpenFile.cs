using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class OpenFile
    {
        DisplayHelper displayHelper = new DisplayHelper();

        public string GetFileContent(string filePath , OpenFileDialog openFileDialog)
        {

            var fileContent = string.Empty;
            //Read the contents of the file into a stream
            var fileStream = openFileDialog.OpenFile();
            try
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                displayHelper.ShowWarning("Exception", ex.Message);
            }
            return fileContent;

        }
        public string OpenFileDialogue()
        {
            var filecontent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "matlab files (*.m)|*.m";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        filecontent = GetFileContent(filePath, openFileDialog);
                    }
                    catch(Exception ex)
                    {
                        displayHelper.ShowWarning("Exception", ex.Message);

                    }
                }
            }

            return filecontent;
           // MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);

        }
    }
}
