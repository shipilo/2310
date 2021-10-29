using System;
using System.Collections.Generic;
using System.Linq;

namespace Les_2310
{
    class Program
    {
        static void Main(string[] args)
        {
            Hierarchy company = new Hierarchy();

            company.AddLevel("Генеральный_директор", new Person[1] { new Person("Борис") });

            company.AddLevel("Директоры_отделов", 
                company.Levels.Last.Value.CurrentPersons["Борис"],
                new Person("О Ильхам"),
                new Person("Рашид"),
                new Person("Лукас"));

            company.AddLevel("Отдел_информационных_технологий",
                company.Levels.Last.Value.CurrentPersons["О Ильхам"],
                new Person("Оркадий", new List<Person>() { new Person("Володя") }));

            company.AddLevel(
                company.Levels.Last.Value.CurrentPersons["Оркадий"],
                new Person("Ильшат", "Системный_сектор"),
                new Person("Сергей", "Сектор_разработки_и_сопровождения"));

            company.AddLevel("Системный_сектор",
               company.Levels.Last.Value.CurrentPersons["Ильшат"],
               new Person("Иваныч"));

            company.AddLevel("Системный_сектор",
                company.Levels.Last.Value.CurrentPersons["Иваныч"],
                new Person("Илья"),
                new Person("Витя"),
                new Person("Женя"));

            company.AddPersons(company.Levels.Last.Previous,
                company.Levels.Last.Previous.Previous.Value.CurrentPersons["Сергей"],
                new Person("Ляйсан", "Сектор_разработки_и_сопровождения"));

            company.AddPersons(company.Levels.Last,
                company.Levels.Last.Previous.Value.CurrentPersons["Ляйсан"],
                new Person("Марат", "Сектор_разработки_и_сопровождения"),
                new Person("Дина", "Сектор_разработки_и_сопровождения"),
                new Person("Ильдар", "Сектор_разработки_и_сопровождения"),
                new Person("Антон", "Сектор_разработки_и_сопровождения"));

            List<Problem> problems = new List<Problem>();

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Введите признак (1 - системщики, 2 - разработчики, 0 - получить результат):");
                string tag_str = Console.ReadLine();
                if (tag_str == "0")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Введите назначающего:");
                    string appointing = Console.ReadLine();
                    Console.WriteLine("Введите назначенца:");
                    string appointee = Console.ReadLine();
                    int tag;
                    if (int.TryParse(tag_str, out tag))
                    {
                        if (tag == 1 || tag == 2)
                        {
                            if (company.LevelOfPersons.Keys.Contains(appointing) && company.LevelOfPersons.Keys.Contains(appointee))
                            {
                                problems.Add(new Problem((Tag)tag, company.LevelOfPersons[appointing].Value.CurrentPersons[appointing], company.LevelOfPersons[appointee].Value.CurrentPersons[appointee]));
                                Console.WriteLine("Задача добавлена.");
                            }
                        }
                    }
                }
            }
            int k = 0;
            foreach (Problem problem in problems)
            {
                bool result = false;

                Person linkPerson = problem.Appointee;

                if (problem.Tag.ToString().Equals(linkPerson.Tag))
                {
                    while (linkPerson != null)
                    {
                        foreach (Person dep in linkPerson.DepPersons)
                        {
                            if (dep.Name.Equals(problem.Appointing.Name))
                            {
                                result = true;
                                linkPerson = null;
                                break;
                            }
                        }
                        if (!result)
                        {
                            if (linkPerson.Name.Equals(problem.Appointing.Name))
                            {
                                result = true;
                                linkPerson = null;
                            }
                            else
                            {
                                linkPerson = linkPerson.UnderPerson;
                            }
                        }
                    }
                }

                Console.WriteLine($"{++k}. {problem} : {result}");
            }

            Console.ReadLine();
        }
    }
}
