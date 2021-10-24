using System.Collections.Generic;

namespace Les_2310
{
    public class Person
    {
        public string Name;
        public List<Person> DepPersons;
        public List<Person> SubPersons;
        public Person()
        {
        }
        public Person(string Name)
        {
            this.Name = Name;
            DepPersons = new List<Person>();
            SubPersons = new List<Person>();
        }
        public Person(string Name, List<Person> DepPersons) : this(Name)
        {
            this.DepPersons = DepPersons;            
        }
    }
}
