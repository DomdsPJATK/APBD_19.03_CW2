using System.IO;
using APBD_19._03_CW2.Model;

namespace APBD_19._03_CW2.MyUtils
{
    public class LogWriter : IDataWriter
    {
        private string path;
        public LogWriter(string path)
        {
            this.path = path;
        }

        public void WriteData(string path, University university)
        {
            throw new System.NotImplementedException();
        }

        public void WriteData(string message)
        {
            if(path == null) return;
            
            using (StreamWriter stream = new StreamWriter(path,true))
            {
                stream.WriteLine(message);
                stream.Flush();
                stream.Close();
            }
        }
        
    }
}