using System.Collections.Generic;

namespace Les_2310
{
    public class Person
    {
        public string Name;
        public string Tag;
        public Person UnderPerson;
        public List<Person> DepPersons;       
        public Person(string Name)
        {
            this.Name = Name;
            DepPersons = new List<Person>();
        }
        public Person(string Name, List<Person> DepPersons) : this(Name)
        {
            this.DepPersons = DepPersons;            
        }
        public Person(string name, string tag) : this(name)
        {
            Tag = tag;
        }
    }
}
