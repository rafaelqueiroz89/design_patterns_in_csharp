using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class MyString
    {
        private StringBuilder sb = new StringBuilder();

        public MyString(string s)
        {
            sb.Append(s);
        }

        public StringRange GetRange(int start, int length)
        {
            return new StringRange(this, start, length);
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public class StringRange
        {
            MyString myS;
            int start, length;

            public StringRange(MyString myS, int start, int length)
            {
                this.myS = myS;
                this.start = start;
                this.length = length;
            }

            public StringRange Set(string s)
            {
                string sub;

                if (s == String.Empty)
                {
                    sub = myS.sb.ToString().Substring(start, length);
                    myS.sb.Replace(sub, s);
                }

                else
                {
                    sub = s;
                    myS.sb.Insert(start, s);
                }
 
                return this;
            }
        }
    }

    class Exercise
    {
        public static void Main()
        {
            var s = new MyString("notation");
            var range = s.GetRange(2, 2);
            range.Set("");
            Console.WriteLine(s.ToString()); // prints 'notion'

            var s1 = new MyString("notation");
            var range2 = s1.GetRange(3, 4);
            range2.Set("ific");
            Console.WriteLine(s1.ToString()); // prints 'notification'
        }
    }
}
