using System.Collections.Generic;
using System.Xml.Serialization;

namespace APBD_19._03_CW2.Model
{
    public class University
    {
        [XmlArray("studenci")]
        [XmlArrayItem("student")]
        public List<Student> listOfStudents { get; set; }
        
        [XmlAttribute]
        public string createdAt { get; set; }
        [XmlAttribute]
        public string author { get; set; }
    }
}