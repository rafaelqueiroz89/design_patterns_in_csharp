using Coding.Exercise;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/// <summary>
/// Treating individual and aggregate objects uniformly
/// Foo and Collection<Foo> have common APIs
/// A mechanism for treating individual (scalar) objects and compositions of objects in an uniform manner
/// 
/// The composite pattern focus on building Parent and Child. Like a menubar. 
/// You can have a single value or many values added to the container through an interface
/// </summary>

namespace Coding.Exercise
{
    public interface IValueContainer : IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return Value;
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {
        public List<int> list;
    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }

    public class MainProgram
    {
        public static void Main(string[] Args)
        {
            List<IValueContainer> container = new List<IValueContainer>();

            //First singlevalue
            var cont = new SingleValue();
            cont.Value = 20;
            container.Add(cont);

            //First singlevalue
            var cont2 = new SingleValue();
            cont2.Value = 30;
            container.Add(cont2);

            //Many values
            var manyvalues = new ManyValues();
            manyvalues.Add(100);
            manyvalues.Add(1);
            container.Add(manyvalues);
            
            //results must be: 20 + 30 + 100 + 1 = 151
            Console.Write(ExtensionMethods.Sum(container));
            Console.ReadKey();
        }
    }
}


