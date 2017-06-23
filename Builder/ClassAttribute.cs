using System.Collections.Generic;
using System.Text;

/*
 * A builder is a separate component for builing an object
 * Can either give builder a constructor or return it via a static function
 * To make builder fluent, return this (AddChild Thing nested on the same element)
 * Different facets of an object can be built with different builders working in tandem (conjunto) via a base class
 * Facets are methods or a particular behavior of an object like (object home, home.At(), home.InCountry()
 */
namespace Builder
{
    public class ClassAttribute
    {
        public string Type, Name, ClassName;
        public List<ClassAttribute> Attributes = new List<ClassAttribute>();
        private const int indentSize = 2;

        public ClassAttribute()
        {

        }

        public ClassAttribute(string name, string type)
        {
            Type = type;
            Name = name;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            int cont = 0;

            if (!string.IsNullOrWhiteSpace(ClassName))
            {
                sb.Append($"{i}public class {ClassName}\n");
                sb.Append("{\n");       
            }

            if (!string.IsNullOrWhiteSpace(Type) && !string.IsNullOrWhiteSpace(Name))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append($"public {Type} {Name};\n");
            }
            
            else
                if (Attributes.Count == 0)
                    sb.Append("}");

            foreach (var e in Attributes)
            {
                cont++;
                sb.Append(e.ToStringImpl(indent));
                
                if (cont == Attributes.Count)
                    sb.Append("}");
            }

           
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}

