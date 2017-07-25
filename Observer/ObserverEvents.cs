using System;

/// <summary>
/// You can use the Observer Pattern when you need to be informed when certain things
/// happen. Like a property change of an object, or when an object does something or when some
/// external events occurs.
/// Built in C# with the 'event' keyword !
/// </summary>
namespace DotNetDesignPatternDemos.Behavioral.Observer
{
    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public void CatchACold()
        {
            FallsIll?.Invoke(this,
              new FallsIllEventArgs { Address = "123 London Road" });
        }

        public event EventHandler<FallsIllEventArgs> FallsIll;
    }

    public class Demo
    {
        //static void Main()
        //{
        //    var person = new Person();

        //    person.FallsIll += CallDoctor;

        //    person.CatchACold();
        //}

        private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }
    }
}