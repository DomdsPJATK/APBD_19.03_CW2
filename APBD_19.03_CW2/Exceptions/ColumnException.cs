using System;
using System.Runtime.CompilerServices;
using APBD_19._03_CW2.MyUtils;

namespace APBD_19._03_CW2.Exceptions
{
    public class ColumnException : Exception
    {
        public ColumnException(string message,string path, string str) : base(message)
        {
            new LogWriter(path).WriteData(str);
        }

        public ColumnException(string path, string str) : base("Niepoprawna liczba kolumn")
        {
            new LogWriter(path).WriteData(str);
        }

        public ColumnException() : base("Niepoprawna liczba kolumn"){}
    }
}