using System.Collections.Generic;

namespace Les_2310
{
    class Hierarchy
    {
        public class Level
        {
            public string Tag;
            public Person UnderPerson;
            public Dictionary<string, Person> CurrentPersons;
            public Level(string tag)
            {
                Tag = tag;
            }
        } 

        public LinkedList<Level> Levels = new LinkedList<Level>();
        public Dictionary<string, LinkedListNode<Level>> LevelOfPersons;
        public Hierarchy()
        {
            LevelOfPersons = new Dictionary<string, LinkedListNode<Level>>();
        }        
        public void AddLevel(string Tag, params Person[] Persons)
        {
            Levels.AddLast(new Level(Tag));
            Levels.Last.Value.CurrentPersons = new Dictionary<string, Person>();
            foreach(Person person in Persons)
            {
                Levels.Last.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Last);
                foreach (Person dep in person.DepPersons)
                {
                    LevelOfPersons.Add(dep.Name, Levels.Last);
                }
            }
        }
        public void AddLevel(string Tag, Person UnderPerson, params Person[] Persons)
        {
            Levels.AddLast(new Level(Tag));
            Levels.Last.Value.UnderPerson = UnderPerson;
            Levels.Last.Value.CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                Levels.Last.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Last);
                foreach (Person dep in person.DepPersons)
                {
                    LevelOfPersons.Add(dep.Name, Levels.Last);
                }
            }
            UnderPerson.SubPersons = new List<Person>(Persons);
        }       
    }
}
