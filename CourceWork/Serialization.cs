using System;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{

    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public Person() { }
        public Person(int id) { Id = id; }
    }

}
