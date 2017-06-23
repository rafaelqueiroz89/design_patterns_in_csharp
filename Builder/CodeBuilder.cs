/*
 * A builder is a separate component for builing an object
 * Can either give builder a constructor or return it via a static function
 * To make builder fluent, return this (AddChild Thing nested on the same element)
 * Different facets of an object can be built with different builders working in tandem (conjunto) via a base class
 * Facets are methods or a particular behavior of an object like (object home, home.At(), home.InCountry()
 */
namespace Builder
{
    public class CodeBuilder
    {
        private readonly string classname;
        ClassAttribute root = new ClassAttribute();

        public CodeBuilder(string classname)
        {
            this.classname = classname;
            root.ClassName = classname;
        }

        public CodeBuilder AddField(string name, string type)
        {
            var e = new ClassAttribute(name, type);
            root.Attributes.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new ClassAttribute { ClassName = classname };
        }
    }
}

