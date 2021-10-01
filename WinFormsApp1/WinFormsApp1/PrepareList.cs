using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class PrepareList
    {
        public void MakeList(List<string> Variable, ArrayList Value, FileVariables fileVariable)
        {
            Variable.Add(fileVariable.Name);

            if (fileVariable.Data_Type == FileVariables.DataTypes.INTEGER)
            {
                Value.Add(fileVariable.DefaultInt);
            }
            else if (fileVariable.Data_Type == FileVariables.DataTypes.REAL)
            {
                Value.Add(fileVariable.DefaultDouble);
            }
            else if (fileVariable.Data_Type == FileVariables.DataTypes.STRING)
            {
                Value.Add(fileVariable.DefaultStr);
            }
            else if (fileVariable.Data_Type == FileVariables.DataTypes.INTEGERARRAY)
            {
                
                string str = "";
                for (int j = 0; j < fileVariable.DefaultIntArray.Length - 1; j++)
                {
                    str += (Convert.ToString(fileVariable.DefaultIntArray[j]) + ",");
                }
                str += (Convert.ToString(fileVariable.DefaultIntArray[fileVariable.DefaultIntArray.Length - 1]));
                Value.Add(str);
            }
            else if (fileVariable.Data_Type == FileVariables.DataTypes.REALARRAY)
            {
                string str = "";
                for (int j = 0; j < fileVariable.DefaultDoubleArray.Length - 1; j++)
                {
                    str += (Convert.ToString(fileVariable.DefaultDoubleArray[j]) + ",");

                }
                str += (Convert.ToString(fileVariable.DefaultDoubleArray[fileVariable.DefaultDoubleArray.Length - 1]));
                Value.Add(str);
            }
            else if (fileVariable.Data_Type == FileVariables.DataTypes.STRINGARRAY)
            {
                string str = "";
                for (int j = 0; j < fileVariable.DefaultStrArray.Length - 1; j++)
                {
                    str += ((fileVariable.DefaultStrArray[j]) + ",");

                }
                str += (Convert.ToString(fileVariable.DefaultStrArray[fileVariable.DefaultStrArray.Length - 1]));
                Value.Add(str);
            }
        }

        public void InputAndOutputList(List<FileVariables> fileVariables)
        { 
            List<string> inputVar = new List<string>();
            ArrayList inputValue = new ArrayList();
            List<string> outputVar = new List<string>();
            ArrayList outputValue = new ArrayList();
            
            foreach (FileVariables fileVariable in fileVariables)
            {
                if (fileVariable.VariableType == FileVariables.VariableTypes.OUTPUT)
                {
                    MakeList(outputVar, outputValue, fileVariable);
                }
                else if (fileVariable.VariableType == FileVariables.VariableTypes.INPUT)
                {
                    MakeList(inputVar, inputValue, fileVariable);
                }
            }

            DisplayHelper displayHelper = new DisplayHelper();
            displayHelper.DisplayListHelper(inputVar, inputValue, outputVar, outputValue);
        }
    }
}
