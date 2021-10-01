using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class DisplayHelper
    {
        public void ShowWarning(string MessageType, string MessageToShow)
        {
            MessageBox.Show(MessageType, MessageToShow, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DisplayListHelper(List<string> inputVar, ArrayList inputValue, List<string> outputVar,
            ArrayList outputValue)
        {
            string ResultList = "InputVariables \nVariableName     DefaultValue\n";

            for (int i = 0; i < inputVar.Count; i++)
            {
                ResultList += string.Format("{0,-35} {1,-25}\n", inputVar[i], inputValue[i]);
            }
            ResultList += "\nOutVariables \nVariableName     DefaultValue\n";
            for (int i = 0; i < outputVar.Count; i++)
            {
                ResultList += string.Format("{0,-35} {1,-20}\n", outputVar[i], outputValue[i]);
            }
            MessageBox.Show(ResultList);
        }
    }
}
