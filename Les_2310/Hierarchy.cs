using System.Collections.Generic;

namespace Les_2310
{
    class Hierarchy
    {
        public LinkedList<Level> Levels;
        public Dictionary<string, LinkedListNode<Level>> LevelOfPersons;
        public class Level
        {            
            public Dictionary<string, Person> CurrentPersons;            
        } 
        public Hierarchy()
        {
            Levels = new LinkedList<Level>();
            LevelOfPersons = new Dictionary<string, LinkedListNode<Level>>();
        }        
        public void AddLevel(string Tag, params Person[] Persons)
        {
            Levels.AddLast(new Level());
            Levels.Last.Value.CurrentPersons = new Dictionary<string, Person>();
            foreach(Person person in Persons)
            {
                person.Tag = Tag;
                Levels.Last.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Last);
                foreach (Person dep in person.DepPersons)
                {
                    Levels.Last.Value.CurrentPersons.Add(dep.Name, dep);
                    LevelOfPersons.Add(dep.Name, Levels.Last);
                    dep.Tag = Tag;
                }
            }
        }
        public void AddLevel(string Tag, Person UnderPerson, params Person[] Persons)
        {
            Levels.AddLast(new Level());
            Levels.Last.Value.CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                person.Tag = Tag;
                person.UnderPerson = UnderPerson;
                Levels.Last.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Last);
                foreach (Person dep in person.DepPersons)
                {
                    Levels.Last.Value.CurrentPersons.Add(dep.Name, dep);
                    LevelOfPersons.Add(dep.Name, Levels.Last);
                    dep.Tag = Tag;
                }
            }
        }
        public void AddLevel(params Person[] Persons)
        {
            Levels.AddLast(new Level());
            Levels.Last.Value.CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                Levels.Last.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Last);
                foreach (Person dep in person.DepPersons)
                {
                    Levels.Last.Value.CurrentPersons.Add(dep.Name, dep);
                    LevelOfPersons.Add(dep.Name, Levels.Last);
                }
            }
        }
        public void AddLevel(Person UnderPerson, params Person[] Persons)
        {
            Levels.AddLast(new Level());
            Levels.Last.Value.CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                person.UnderPerson = UnderPerson;
                Levels.Last.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Last);
                foreach (Person dep in person.DepPersons)
                {
                    Levels.Last.Value.CurrentPersons.Add(dep.Name, dep);
                    LevelOfPersons.Add(dep.Name, Levels.Last);
                }
            }
        }
        public void AddPersons(LinkedListNode<Level> Level, Person UnderPerson, params Person[] Persons)
        {
            foreach (Person person in Persons)
            {
                person.UnderPerson = UnderPerson;
                Level.Value.CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Level);
                foreach (Person dep in person.DepPersons)
                {
                    Level.Value.CurrentPersons.Add(dep.Name, dep);
                    LevelOfPersons.Add(dep.Name, Level);
                }
            }
        }
    }
}
