using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class ParseData
    {
        public List<FileVariables> GetData()
        {
            string FormData;

            OpenFile openFile = new OpenFile();
            FormData = openFile.OpenFileDialogue();

            string[] SplitedData = FormData.Split("% variable: ");

            var FileVariablesList = new List<FileVariables>();

            for (int i = 1; i < SplitedData.Length - 1; i++)
            {
                FileVariables fileVariables = new FileVariables();
                /// should work for multiple spaces. 
                /// I need to check/.
                String currentData =Regex.Replace(SplitedData[i], @"\s+", " ");
                string[] Data = currentData.Split(" ");

                fileVariables.Name = Data[0];

                if (Data[1] == "int" || Data[1] == "double" || Data[1] == "string")
                {
                    fileVariables.DataType = Data[1];
                }
                else if (Data[1] == "int[]" || Data[1] == "double[]" || Data[1] == "string[]")
                {
                    fileVariables.DataType = Data[1].Replace("[]","Array");
                    //MessageBox.Show(fileVariables.DataType);
                }
                else
                {
                    //Exception show korbo
                    MessageBox.Show("Warning", "Wrong Variable Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                if (Data[2] == "output" || Data[2] == "input")
                {
                    fileVariables.VariableType = Data[2];
                }
                else
                {
                    MessageBox.Show("Warning","Wrong Variable Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //fileVariables.VariableType = Data[2].Trim();

                if (Data.Length == 5)
                {
                    //fileVariables.DefaultStr = Data[3].Split("=")[1];
                    string DefaultData = Data[3].Split("=")[1];
                    if(fileVariables.DataType == "int")
                    {
                        int defaultInt;
                        try
                        {
                            defaultInt = Convert.ToInt32(DefaultData);
                            fileVariables.DefaultInt = defaultInt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (fileVariables.DataType == "double")
                    {
                        double defaultDouble;
                        try
                        {
                            defaultDouble = Convert.ToDouble(DefaultData);
                            fileVariables.DefaultDouble = defaultDouble;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (fileVariables.DataType == "string")
                    {  
                        fileVariables.DefaultStr = DefaultData;
                    }
                    else if (fileVariables.DataType == "intArray")
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
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (fileVariables.DataType == "doubleArray")
                    {
                        //MessageBox.Show("Im here");
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
                            MessageBox.Show(str);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (fileVariables.DataType == "stringArray")
                    {

                        try
                        {
                            string[] elements = DefaultData.Split(",");
                            
                            fileVariables.DefaultStrArray = elements;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    fileVariables.UpperBound = 0;
                    fileVariables.LowerBound = 0;
                }
                else if (Data.Length == 7)
                {
                    string DefaultData = Data[3].Split("=")[1];
                    if (fileVariables.DataType == "int")
                    {
                        int defaultInt;
                        try
                        {
                            defaultInt = Convert.ToInt32(DefaultData);
                            fileVariables.DefaultInt = defaultInt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (fileVariables.DataType == "double")
                    {
                        double defaultDouble;
                        try
                        {
                            defaultDouble = Convert.ToDouble(DefaultData);
                            fileVariables.DefaultDouble = defaultDouble;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (fileVariables.DataType == "string")
                    {
                        fileVariables.DefaultStr = DefaultData;
                    }
                    else if (fileVariables.DataType == "intArray")
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
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (fileVariables.DataType == "doubleArray")
                    {

                        try
                        {
                            string[] elements = DefaultData.Split(",");
                            double[] defaultDouble = new double[elements.Length];
                            string str = "";
                            for (int j = 0; j < elements.Length; j++)
                            {
                                defaultDouble[j] = Convert.ToDouble(elements[j]);
                                //str += (Convert.ToString(defaultDouble[j]) + ",");
                            }

                            fileVariables.DefaultDoubleArray = defaultDouble;
                            

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (fileVariables.DataType == "stringArray")
                    {

                        try
                        {
                            string[] elements = DefaultData.Split(",");

                            fileVariables.DefaultStrArray = elements;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Warning", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    fileVariables.UpperBound = Convert.ToInt64(Data[4].Split("=")[1]);
                    fileVariables.LowerBound = Convert.ToInt64(Data[5].Split("=")[1]);
                }
                else
                {
                    if (fileVariables.DataType == "int")
                    {
                        fileVariables.DefaultInt = 0;
                    }
                    else if (fileVariables.DataType == "double")
                    {
                        fileVariables.DefaultDouble = 0.0;
                    }
                    else if (fileVariables.DataType == "string")
                    {
                        fileVariables.DefaultStr = "";
                    }
                    else if (fileVariables.DataType == "intArray")
                    {
                        fileVariables.DefaultIntArray = new int[5] { 0,0,0,0,0 };
                    }
                    else if (fileVariables.DataType == "doubleArray")
                    {
                        fileVariables.DefaultDoubleArray = new double[5] { 0.0, 0.0, 0.0, 0.0, 0.0 };
                    }
                    else if (fileVariables.DataType == "stringArray")
                    {
                        fileVariables.DefaultStrArray = new string[5] {"", "", "", "", "" };
                    }
                    fileVariables.UpperBound = 0;
                    fileVariables.LowerBound = 0;
                }

                //MessageBox.Show(Data.Length.ToString());
                //MessageBox.Show(fileVariables.Name);
                //MessageBox.Show(fileVariables.DataType);
                //MessageBox.Show(fileVariables.VariableType);
                //MessageBox.Show(fileVariables.DefaultStr);
                //MessageBox.Show(fileVariables.UpperBound.ToString());
                //MessageBox.Show(fileVariables.LowerBound.ToString());

                FileVariablesList.Add(fileVariables);

            }

            return FileVariablesList;


        }
    }
}
