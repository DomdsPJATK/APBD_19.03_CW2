using System;
using System.Xml.Serialization;

namespace APBD_19._03_CW2.Model
{
    [Serializable]
    public class Student
    {        
        [XmlElement(ElementName = "fname")]
        public string name { get; set; }
        [XmlElement(ElementName = "lname")]
        public string surname { get; set; }
        [XmlAttribute(AttributeName = "IndexNumber")]
        public string index { get; set; }
        public DateTime birthdate{ get; set; }
        public string email{ get; set; }
        public string mothersName{ get; set; }
        public string fathersName{ get; set; }
        
        [XmlElement(ElementName = "studies")]
        public Mode mode { get; set; }
        
    }
}