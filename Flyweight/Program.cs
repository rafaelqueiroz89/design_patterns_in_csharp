using System;
using System.Text;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            Sentence sentence = new Sentence("ALPHA BETA GAMMA");
            sentence[0].Capitalize = true;
            sentence[1].Capitalize = false;
            sentence[2].Capitalize = true;
            Console.WriteLine(sentence); // writes "ALPHA beta GAMMA"
        }
    }

    public class Sentence
    {
        public static string[] splitWords;

        public Sentence(string plainText)
        {
            splitWords = plainText.Split(' ');
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < splitWords.Length; i++)
            {
                if (WordToken.capitalize[i])
                    sb.Append($"{splitWords[i].ToUpper()} ");
                else
                    sb.Append($"{splitWords[i].ToLower()} ");
            }
            return sb.ToString().Trim();
        }

        public WordToken this[int index]
        {
            get
            {
                // get the item for that index.
                return new WordToken(index);
            }
        }


        public class WordToken
        {
            public static Dictionary<int, bool> capitalize = new Dictionary<int, bool>();
            private int index;

            public WordToken(int index)
            {
                this.index = index;
            }

            public bool Capitalize
            {
                set
                {
                    capitalize.Add(index, value);
                }

                get
                {
                    return capitalize[index];
                }
            }
        }
    }
}

