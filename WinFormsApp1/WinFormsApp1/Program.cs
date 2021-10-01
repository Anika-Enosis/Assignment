using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            OpenFile openFile = new OpenFile();
            string FormData = openFile.OpenFileDialogue();

            List<FileVariables> fileVariables = new List<FileVariables>();
            ParseData parseData = new ParseData();
            fileVariables = parseData.GetData(FormData);

            PrepareList displayList = new PrepareList();
            displayList.InputAndOutputList(fileVariables);
        }
    }
}
