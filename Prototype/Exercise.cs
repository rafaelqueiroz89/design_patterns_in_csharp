using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// A design pattern that helps us clone objects in OOD, not a shallow copy (copy only the references) but a deep clone
/// through serialization
/// </summary>
namespace Prototype
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }


    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            Line l = new Line();
            l.Start = new Point { X = Start.X, Y = Start.Y };
            l.End = new Point { X = End.X, Y = End.Y };
            return l;
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start.X} {Start.Y}, {nameof(End)}: {End.X} {End.Y}";
        }
    }

    public static class CopyThroughSerialization
    {
        static void Main()
        {
         
            Line linha1 = new Line { Start = new Point { X = 1, Y = 2 }, End = new Point { X = 9, Y = 5 } };
            linha1.DeepCopy();

            //i want to copy line 1 into line 2
            Line linha2 = linha1.DeepCopy();

            //    Foo foo = new Foo { Stuff = 42, Whatever = "abc" };

            //    //Foo foo2 = foo.DeepCopyXml(); // crashes without [Serializable]

            //    foo2.Whatever = "xyz";
            //    WriteLine(foo);
            //    WriteLine(foo2);
            //    ReadKey();
        }
    }
}
