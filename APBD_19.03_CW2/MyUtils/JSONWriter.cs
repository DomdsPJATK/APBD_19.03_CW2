using System.IO;
using System.Text.Json;
using APBD_19._03_CW2.Model;

namespace APBD_19._03_CW2.MyUtils
{
    public class JSONWriter : IDataWriter
    {
        public void WriteData(string path, University university)
        {    
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            var jsonString = JsonSerializer.Serialize(university);
            File.WriteAllText("data.json", jsonString);
        }

        public void WriteData(string path)
        {
            throw new System.NotImplementedException();
        }
        
    }
}