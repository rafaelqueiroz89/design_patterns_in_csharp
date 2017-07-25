using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// An interface for accessing a resource.
/// A class that functions as an interface to a particular resource. That resource may be remote,
/// expensive to construct, or may require logging or some other added functionality.
/// </summary>
 
namespace Proxy
{
    interface IResponsible
    {
        string Vote();
        string Drive();
        string DrinkAndDrive();
        string Drink();
    }

    public class Person : IResponsible
    {
        public int Age { get; set; }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }

        public string Vote()
        {
            return "voting";
        }

        public string Drink()
        {
            return "drinking";
        }
    }

    public class ResponsiblePerson : IResponsible
    {
        private Person person;
        public int Age { get; set; }

        public ResponsiblePerson(Person person)
        {
            this.person = person;
            Age = person.Age;
        }

        public string Drink()
        {
            if (Age >= 18)
                return person.Drink();
            else
                return "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public string Drive()
        {
            if (Age > 15)
                return person.Drive();
            else
                return "too young";
        }

        public string Vote()
        {
            if (Age >= 18)
                return person.Vote();
            else
                return "Too young to vote";
        }
    }

    public class Demo
    {
        public static void Main(string[] args)
        {
            IResponsible person = new ResponsiblePerson(new Person { Age = 16 });
            WriteLine(person.Drive());
            ReadKey();
        }
    }
}