using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderListsOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person{ Name = "F", BirthDate = new DateTime(2014, 2, 1) }
                ,new Person{ Name = "A", BirthDate = new DateTime(2015, 2, 1) }
                ,new Person{ Name = "F", BirthDate = new DateTime(2014, 1, 1) }
                ,new Person{ Name = "A", BirthDate = new DateTime(2015, 1, 1) }                
            };


            Console.WriteLine("------- Order By, Linq -------");
            
            IEnumerable<Person> orderedByLinq = people.OrderBy(p => p.Name).ThenBy(p => p.BirthDate); 
            foreach (Person p in orderedByLinq)
            {
                Console.WriteLine("{0}: {1}", p.Name, p.BirthDate.ToShortDateString());
            }


            Console.WriteLine();
            Console.WriteLine("------- Collection.Sort, IComparer -------");
            
            people.Sort(new PersonComparer());
            foreach (Person p in people)
            {
                Console.WriteLine("{0}: {1}", p.Name, p.BirthDate.ToShortDateString());
            }
            
            Console.ReadLine();
        }
    }
}
