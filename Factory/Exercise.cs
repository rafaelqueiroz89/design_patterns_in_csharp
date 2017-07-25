using System;

namespace Factory
{
    /// <summary>
    /// A factory method is a static method that create objects
    /// A factory can take care of object creation
    /// A factory can be external or reside inside the object as an inner class
    /// Hierarchies of factoreies can be used to create related objects
    /// </summary>
    public class Exercise
    {
        static void Main(string[] args)
        {
            var person = Person.PersonFactory.CreatePerson("Bills");
            var person2 = Person.PersonFactory.CreatePerson("Bills2"); 
            var person3 = Person.PersonFactory.CreatePerson("Bills3");
            Console.WriteLine(person);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            Console.ReadKey();
        }
    }
}
