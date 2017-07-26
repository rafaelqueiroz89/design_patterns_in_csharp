using System;
using static System.Console;

namespace Template_Method
{
    public class Creature
    {
        public int Attack, Health;

        public Creature(int attack, int health)
        {
            Attack = attack;
            Health = health;
        }
    }

    public abstract class CardGame
    {
        public Creature[] Creatures;

        public CardGame(Creature[] creatures)
        {
            Creatures = creatures;
        }

        // returns -1 if no clear winner (both alive or both dead)
        public int Combat(int creature1, int creature2)
        {
            Creature first = Creatures[creature1];
            Creature second = Creatures[creature2];

            Hit(first, second);
            Hit(second, first);

            bool firstAlive = first.Health > 0;
            bool secondAlive = second.Health > 0;

            if (firstAlive == secondAlive) return -1;

            return firstAlive ? creature1 : creature2;
        }

        // attacker hits other creature
        protected abstract void Hit(Creature attacker, Creature other);
    }

    public class TemporaryCardDamageGame : CardGame
    {
        public TemporaryCardDamageGame(Creature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            var oldHealth = other.Health;
            other.Health -= attacker.Attack;

            if (other.Health > 0) // if the life's creature that was hit is > 0 then it is still into play
                other.Health = oldHealth;
        }
    }


    public class PermanentCardDamage : CardGame
    { 
        public PermanentCardDamage(Creature[] creatures) : base(creatures)
        {
            
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            other.Health -= attacker.Attack;
        }
    }


    public class Exercise
    {
        public static void Main()
        {
            Creature[] creatures = { new Creature(9, 9), new Creature(1, 1), new Creature(1, 1), new Creature(12, 12) };
            TemporaryCardDamageGame temp = new TemporaryCardDamageGame(creatures);

            WriteLine($"Combat result is: {temp.Combat(1, 2)}"); //prints -1 because both are dead
            WriteLine($"Combat result is: {temp.Combat(0, 1)}"); //prints 0 because creature 0 is alive

            PermanentCardDamage perm = new PermanentCardDamage(creatures);
            WriteLine($"\nCombat result is: {temp.Combat(1, 2)}"); //prints -1 because both are dead
            WriteLine($"Combat result is: {temp.Combat(0, 1)}"); //prints 0 because creature 0 is alive but hurt
            WriteLine($"Combat result is: {temp.Combat(0, 3)}"); //prints 3 (because creature 3 is alive)
        }
    }
}


