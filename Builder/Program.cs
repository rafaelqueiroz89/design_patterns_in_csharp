using static System.Console;

/*
 * A builder is a separate component for builing an object
 * Can either give builder a constructor or return it via a static function
 * To make builder fluent, return this (AddChild Thing nested on the same element)
 * Different facets of an object can be built with different builders working in tandem (conjunto) via a base class
 * Facets are methods or a particular behavior of an object like (object home, home.At(), home.InCountry()
 */
namespace Builder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            WriteLine(cb);
            ReadKey();
        }
    }
}

