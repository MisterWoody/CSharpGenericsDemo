using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // Previously to generics, C# had ArrayList which has no specific typing but will allow objects to be added.
            // ArrayList is a deprecated feature - DO NOT USE IT!

            //List<int> ages = new List<int>();
            //ages.Add(23);

            ArrayList list = new ArrayList();
            
            list.Add(23);
            list.Add("Hello");  // Because ArrayList is not constrained by type, we can add mismatched types to it that are not picked up by the compiler.

            int val = (int)list[0];  // We can cast the arraylist element to a specific type (that can work if it's the right type)
            int val2 = (int)list[1]; // No compile time error here if we try to cast an object to int (even if it's a string) - throws a runtime exception!
            
            
            Console.WriteLine();
            Console.Write("Press enter to shut down...");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string peopleFile = @"C:\Temp\people.csv";
            string logFile = @"C:\Temp\logs.csv";

            PopulateLists(people, logs);

            OriginalTextFileProcessor.SavePeople(people, peopleFile);

            var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            }
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
            people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }
}
