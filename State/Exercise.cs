using System;
using static System.Console;

namespace State
{
    class CombinationLock
    {
        public enum State
        {
            LOCKED,
            OPEN,
            ERROR
        }

        private int[] combination;
        private int correct_digits;
        public string Status; // you need to be changing this on user input

        public CombinationLock(int[] combination)
        {
            this.combination = combination;
            Status = nameof(State.LOCKED);
        }

        public void EnterDigit(int digit)
        {
            if (correct_digits <= combination.Length)
            {
                WriteLine($"Digit entered: {digit}");

                if (digit == combination[correct_digits])
                {
                    correct_digits++;
                    Status = string.Empty;

                    if (correct_digits == combination.Length)
                        Status = nameof(State.OPEN);
                    else
                        for (int i = 0; i < correct_digits; i++)
                            Status += combination[i];
                }

                else
                    Status = nameof(State.ERROR);
            }
        }
    }

    class Exercise
    {
        public static void Main()
        {
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
            WriteLine($"STATUS: {cl.Status}"); //Assert.That(cl.Status, Is.EqualTo("LOCKED"));  
            cl.EnterDigit(1);
            WriteLine($"STATUS: {cl.Status}"); //Assert.That(cl.Status, Is.EqualTo("1"));
            cl.EnterDigit(2);
            WriteLine($"STATUS: {cl.Status}"); //Assert.That(cl.Status, Is.EqualTo("2"));
            cl.EnterDigit(3);
            WriteLine($"STATUS: {cl.Status}"); //Assert.That(cl.Status, Is.EqualTo("3"));
            cl.EnterDigit(4);
            WriteLine($"STATUS: {cl.Status}"); //Assert.That(cl.Status, Is.EqualTo("4"));
            cl.EnterDigit(5);
            WriteLine($"STATUS: {cl.Status}"); //Assert.That(cl.Status, Is.EqualTo("OPEN"));
        }
    }
}
