using System.Collections.Generic;
using static System.Console;

namespace DotNetDesignPatternDemos.Creational.Singleton.Monostate
{
    public class ChiefExecutiveOfficer
    {
        //use static fields to set the constructor
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    public class Demo
    {
        static void Main_(string[] args)
        {
            var ceo = new ChiefExecutiveOfficer();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;

            //let you call the constructor but doesn't create a new object, it instead use the first one instanciated
            var ceo2 = new ChiefExecutiveOfficer();
            WriteLine(ceo2);
        }
    }
}