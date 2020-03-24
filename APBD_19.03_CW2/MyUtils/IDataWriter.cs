using System;
using APBD_19._03_CW2.Model;

namespace APBD_19._03_CW2.MyUtils
{
    public interface IDataWriter
    {
        public void WriteData(string path, University university);
        public void WriteData(string path);
    }
}