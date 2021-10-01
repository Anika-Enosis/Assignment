using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class ParseData
    {
        DisplayHelper displayHelper = new DisplayHelper();
        
        public void SetName(string Name, FileVariables fileVariable)
        {
            fileVariable.Name = Name;
        }

        public void SetDataType(string DataType, FileVariables fileVariable)
        {
            if (DataType == "int" || DataType == "double" || DataType == "string")
            {
               // fileVariable.DataType = DataType;
                if(DataType == "int")
                {
                    fileVariable.Data_Type = FileVariables.DataTypes.INTEGER;
                }
                else if (DataType == "double")
                {
                    fileVariable.Data_Type = FileVariables.DataTypes.REAL;
                }
                else if (DataType == "string")
                {
                    fileVariable.Data_Type = FileVariables.DataTypes.STRING;
                }
            }
            else if (DataType == "int[]" || DataType == "double[]" || DataType == "string[]")
            {
                //fileVariable.DataType = DataType.Replace("[]", "Array");
                //MessageBox.Show(fileVariable.DataType);
                if(DataType == "int[]")
                {
                    fileVariable.Data_Type = FileVariables.DataTypes.INTEGERARRAY;

                }
                else if (DataType == "double[]")
                {
                    fileVariable.Data_Type = FileVariables.DataTypes.REALARRAY;
                }
                else if (DataType == "string[]")
                {
                    fileVariable.Data_Type = FileVariables.DataTypes.STRINGARRAY;

                }
            }
            else
            {
                displayHelper.ShowWarning("Warinig","Wrong Data Type");
               
            }

        }

        public void SetVariableType(string variableType, FileVariables fileVariables)
        {
            if (variableType == "output" || variableType == "input")
            {
                //fileVariables.VariableType = variableType;
                if(variableType == "output")
                {
                    fileVariables.VariableType = FileVariables.VariableTypes.OUTPUT;
                }
                else if(variableType == "input")
                {
                    fileVariables.VariableType = FileVariables.VariableTypes.INPUT;
                }
            }
            else
            {
                displayHelper.ShowWarning("Warning", "Wrong Variable Type");
            }
        }

        public void SetDefaultData(string DefaultValue, FileVariables fileVariables)
        {
            //MessageBox.Show(DefaultValue);
            string DefaultData = DefaultValue.Split("=")[1];

            if (fileVariables.Data_Type == FileVariables.DataTypes.INTEGER)
            {
                int defaultInt;
                try
                {
                    defaultInt = Convert.ToInt32(DefaultData);
                    fileVariables.DefaultInt = defaultInt;
                }
                catch (Exception ex)
                {
                    displayHelper.ShowWarning("Warning", ex.Message);
                }
            }

            else if (fileVariables.Data_Type == FileVariables.DataTypes.REAL)
            {
                double defaultDouble;
                try
                {
                    defaultDouble = Convert.ToDouble(DefaultData);
                    fileVariables.DefaultDouble = defaultDouble;
                }
                catch (Exception ex)
                {
                    displayHelper.ShowWarning("Warning", ex.Message);
                }
            }

            else if (fileVariables.Data_Type == FileVariables.DataTypes.STRING)
            {
                fileVariables.DefaultStr = DefaultData;
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.INTEGERARRAY)
            {

                try
                {
                    string[] elements = DefaultData.Split(",");
                    int[] defaultInt = new int[elements.Length];
                    for (int j = 0; j < elements.Length; j++)
                    {
                        defaultInt[j] = Convert.ToInt32(elements[j]);
                    }

                    fileVariables.DefaultIntArray = defaultInt;
                }
                catch (Exception ex)
                {
                    displayHelper.ShowWarning("Warning", ex.Message);
                }
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.REALARRAY)
            {
                try
                {
                    string[] elements = DefaultData.Split(",");
                    double[] defaultDouble = new double[elements.Length];
                    string str = "";
                    for (int j = 0; j < elements.Length; j++)
                    {
                        defaultDouble[j] = Convert.ToDouble(elements[j]);
                        str += (Convert.ToString(defaultDouble[j]) + ",");
                    }

                    fileVariables.DefaultDoubleArray = defaultDouble;
                    //MessageBox.Show(str);

                }
                catch (Exception ex)
                {
                    displayHelper.ShowWarning("Warning", ex.Message);
                }
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.STRINGARRAY)
            {

                try
                {
                    string[] elements = DefaultData.Split(",");

                    fileVariables.DefaultStrArray = elements;
                }
                catch (Exception ex)
                {
                    displayHelper.ShowWarning("Warning", ex.Message);
                }
            }

        }

        public void SetUpperBound(string UpperBound, FileVariables fileVariables)
        {
            fileVariables.UpperBound = Convert.ToInt64(UpperBound.Split("=")[1]);
            
        }

        public void SetLowerBound(string LowerBound, FileVariables fileVariables)
        {
            fileVariables.LowerBound = Convert.ToInt64(LowerBound.Split("=")[1]);
        }

        public void SetDefaultBounds(FileVariables fileVariables)
        {
            fileVariables.UpperBound = 0;
            fileVariables.LowerBound = 0;
        }

        public void SetDefaultValues(FileVariables fileVariables)
        {
            if (fileVariables.Data_Type == FileVariables.DataTypes.INTEGER)
            {
                fileVariables.DefaultInt = 0;
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.REAL)
            {
                fileVariables.DefaultDouble = 0.0;
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.STRING)
            {
                fileVariables.DefaultStr = "\"\"";
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.INTEGERARRAY)
            {
                fileVariables.DefaultIntArray = new int[5] { 0, 0, 0, 0, 0 };
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.REALARRAY)
            {
                fileVariables.DefaultDoubleArray = new double[5] { 0.0, 0.0, 0.0, 0.0, 0.0 };
            }
            else if (fileVariables.Data_Type == FileVariables.DataTypes.STRINGARRAY)
            {
                fileVariables.DefaultStrArray = new string[5] { "", "", "", "", "" };
            }
        }

        public List<FileVariables> GetData(String FormData)
        {
           
            String currentData = Regex.Replace(FormData, @"\s+", " ");
            currentData = currentData.Replace("\t", " ");
            //MessageBox.Show(currentData);
            string[] SplitedData = currentData.Split("% variable: ");

            var FileVariablesList = new List<FileVariables>();

            for (int i = 1; i < SplitedData.Length; i++)
            {
                string[] Data;
                FileVariables fileVariables = new FileVariables();
                Data = SplitedData[i].Split(" ");
                if ( i == (SplitedData.Length - 1))
                {
                    string Last_Line = SplitedData[i].Split("%")[0];
                    Data = Last_Line.Split(" ");

                }
             
                SetName(Data[0], fileVariables);

                SetDataType(Data[1], fileVariables);

                SetVariableType(Data[2], fileVariables);
                
                if (Data.Length == 5)
                {

                    SetDefaultData(Data[3], fileVariables);

                    SetDefaultBounds(fileVariables);
                }
                else if (Data.Length == 7)
                {
                    
                    SetDefaultData(Data[3], fileVariables);
                    SetUpperBound(Data[4], fileVariables);
                    SetLowerBound(Data[5], fileVariables);
                }
                else
                {
                    SetDefaultValues(fileVariables);
                    SetDefaultBounds(fileVariables);
                }

                FileVariablesList.Add(fileVariables);

            }

            return FileVariablesList;


        }
    }
}
