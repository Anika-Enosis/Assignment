using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class DisplayList
    {
        public void ShowList()
        {
            List<FileVariables> fileVariables = new List<FileVariables>();
            ParseData parseData = new ParseData();
            fileVariables = parseData.GetData();

            List<string> inputVar = new List<string>();
            ArrayList inputValue = new ArrayList();
            List<string> outputVar = new List<string>();
            ArrayList outputValue = new ArrayList();
            string ResultList = "InputVariables \nVariableName     DefaultValue\n";
       
            foreach (FileVariables fileVariable in fileVariables)
            {
                if (fileVariable.VariableType == "output")
                {
                    outputVar.Add(fileVariable.Name);

                    if(fileVariable.DataType == "int")
                    {
                        outputValue.Add(fileVariable.DefaultInt);
                    }
                    else if(fileVariable.DataType == "double")
                    {
                        outputValue.Add(fileVariable.DefaultDouble);
                    }
                    else if(fileVariable.DataType == "string")
                    {
                        outputValue.Add(fileVariable.DefaultStr);
                    }
                    else if (fileVariable.DataType == "intArray")
                    {
                        //outputValue.Add(fileVariable.DefaultIntArray);
                        string str = "";
                        for (int j = 0; j < fileVariable.DefaultIntArray.Length - 1; j++)
                        {
                            //outputValue.Add(fileVariable.DefaultDoubleArray[j]);
                            str += (Convert.ToString(fileVariable.DefaultIntArray[j]) + ",");

                        }
                        str += (Convert.ToString(fileVariable.DefaultIntArray[fileVariable.DefaultIntArray.Length - 1]));
                        outputValue.Add(str);
                    }
                    else if (fileVariable.DataType == "doubleArray")
                    {
                        //outputValue.Add(fileVariable.DefaultDoubleArray);
                        string str = "";
                        for(int j = 0; j < fileVariable.DefaultDoubleArray.Length - 1; j++)
                        {
                            //outputValue.Add(fileVariable.DefaultDoubleArray[j]);
                            str += (Convert.ToString(fileVariable.DefaultDoubleArray[j]) + ",");

                        }
                        str += (Convert.ToString(fileVariable.DefaultDoubleArray[fileVariable.DefaultDoubleArray.Length - 1]));
                        outputValue.Add(str);
                    }
                    else if (fileVariable.DataType == "stringArray")
                    {
                        //outputValue.Add(fileVariable.DefaultStrArray);
                        string str = "";
                        for (int j = 0; j < fileVariable.DefaultStrArray.Length - 1; j++)
                        {
                            str += ((fileVariable.DefaultStrArray[j]) + ",");

                        }
                        str += (Convert.ToString(fileVariable.DefaultStrArray[fileVariable.DefaultStrArray.Length - 1]));
                        outputValue.Add(str);
                    }
                }
                else if (fileVariable.VariableType == "input")
                {
                    inputVar.Add(fileVariable.Name);
                    if (fileVariable.DataType == "int")
                    {
                        inputValue.Add(fileVariable.DefaultInt);
                    }
                    else if (fileVariable.DataType == "double")
                    {
                        inputValue.Add(fileVariable.DefaultDouble);
                    }
                    else if (fileVariable.DataType == "string")
                    {
                        inputValue.Add(fileVariable.DefaultStr);
                    }
                    else if (fileVariable.DataType == "intArray")
                    {
                        //inputValue.Add(fileVariable.DefaultIntArray);
                        string str = "";
                        for (int j = 0; j < fileVariable.DefaultIntArray.Length - 1; j++)
                        {
                            //outputValue.Add(fileVariable.DefaultDoubleArray[j]);
                            str += (Convert.ToString(fileVariable.DefaultIntArray[j]) + ",");

                        }
                        str += (Convert.ToString(fileVariable.DefaultIntArray[fileVariable.DefaultIntArray.Length - 1]));
                        inputValue.Add(str);
                    }
                    else if (fileVariable.DataType == "doubleArray")
                    {
                        //inputValue.Add(fileVariable.DefaultDoubleArray);
                        string str = "";
                        for (int j = 0; j < fileVariable.DefaultDoubleArray.Length - 1; j++)
                        {
                            //outputValue.Add(fileVariable.DefaultDoubleArray[j]);
                            str += (Convert.ToString(fileVariable.DefaultDoubleArray[j]) + ",");

                        }
                        str += (Convert.ToString(fileVariable.DefaultDoubleArray[fileVariable.DefaultDoubleArray.Length - 1]));
                        inputValue.Add(str);
                    }
                    else if (fileVariable.DataType == "stringArray")
                    {
                        //inputValue.Add(fileVariable.DefaultStrArray);
                        string str = "";
                        for (int j = 0; j < fileVariable.DefaultStrArray.Length - 1; j++)
                        {
                            str += ((fileVariable.DefaultStrArray[j]) + ",");

                        }
                        str += (Convert.ToString(fileVariable.DefaultStrArray[fileVariable.DefaultStrArray.Length - 1]));
                        inputValue.Add(str);
                    }
                }
            }
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
