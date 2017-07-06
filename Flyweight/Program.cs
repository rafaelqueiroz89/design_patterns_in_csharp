using System;
using System.Text;
/// <summary>
/// Space optimization! 
/// Avoid redundancy when storing data
/// Eg: MMORPG
/// Plenty of users with identical first/last names. No sense in storing same first/last name 
/// over and over again. Like a common name as Rafael or John Smith
/// 
/// Store a list of names and pointers to them
/// .Net performs string interning, so an identical string is stored only once. Strings are immutable
/// 
/// A space optmization technique that let us use less memory by storing externally the data
/// associated with smilar objects
/// </summary>
namespace Flyweight
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Sentence sentence = new Sentence("hello world");
        //    sentence[1].Capitalize = true;
        //    Console.WriteLine(sentence); // writes "hello WORLD"
        //}
    }

    public class Sentence
    {
        public string[] splitWords;

        public Sentence(string plainText)
        {
            splitWords = plainText.Split(' ');
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < splitWords.Length; i++)
                sb.Append($"{splitWords[i]} ");

            return sb.ToString().Trim();
        }

        public class WordToken : Sentence
        {
            private static bool capitalize;
            private string stringToCapitalize;

            public WordToken(string stringToCapitalize) : base(stringToCapitalize)
            {
                this.stringToCapitalize = stringToCapitalize;
            }
 
            public string StringToCapitalize
            {
                get
                {
                    return stringToCapitalize;
                }
            }

            public bool Capitalize
            {
                get
                {
                    return capitalize;
                }

                set
                {
                    capitalize = value;
                }
            }
        }

        public WordToken this[int index]
        {
            get
            {
                // get the item for that index.
                WordToken wt = new WordToken(splitWords[index]);
                
                splitWords[index] = wt.StringToCapitalize.ToUpper();
                return wt;
            }
        }
    }
}

