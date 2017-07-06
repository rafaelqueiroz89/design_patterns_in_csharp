using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Adding behavior without altering the class itself. 
/// We don't want to rewrite or alter existing code (Open Closed Principle)
/// Want to keep new functionality separate (Single responsability principle)
/// Need to be able to interact with existing structures
/// The sealed keyword says that a class can't be inherited
/// </summary>
namespace Decorator
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        Bird bird = new Bird();
        Lizard liz = new Lizard();

        public int Age { get; set; }

        public string Fly()
        {
            bird.Age = this.Age;
            return bird.Fly();
        }

        public string Crawl()
        {
            liz.Age = this.Age;
            return liz.Crawl();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dragon dg = new Dragon();
            dg.Age = 10;

            Console.WriteLine(dg.Fly());
        }
    }
}

