using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using APBD_19._03_CW2.Model;

namespace APBD_19._03_CW2.MyUtils
{
    public class XMLWriter : IDataWriter
    {
        
        public void WriteData(string path, University university)
        {
            FileStream writer = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(University), new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, university);
        }

        public void WriteData(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}