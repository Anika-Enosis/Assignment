using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    
    class FileVariables
    {
        public enum DataTypes
        {
            INTEGER,
            REAL,
            STRING,
            INTEGERARRAY,
            REALARRAY,
            STRINGARRAY

        }

        public enum VariableTypes
        {
            INPUT,
            OUTPUT
        }
        public string Name { get; set; }

        public string DataType { get; set; }

        public DataTypes Data_Type { get; set; }

        public VariableTypes VariableType { get; set; }

        public string DefaultStr { get; set; }

        public int DefaultInt { get; set; }
        
        public double DefaultDouble { get; set; }

        public string[] DefaultStrArray { get; set; }

        public int[] DefaultIntArray { get; set; }

        public double[] DefaultDoubleArray { get; set; }


        public long UpperBound { get; set; }

        public long LowerBound { get; set; }

        


    }
}
