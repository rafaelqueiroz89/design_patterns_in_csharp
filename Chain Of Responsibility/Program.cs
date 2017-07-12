using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/// <summary>
/// A chain of compononents that get a chance to process a command or a query, optionally
/// having default processing implementation and an ability to terminate the processing chain.
/// The principle is like a panel where you can controls inside it like it was in windows forms or WPF.
/// 
/// It can be used in games!
/// </summary>
namespace Chain_Of_Responsibility
{
    using System;
    using System.Collections.Generic;

    namespace Coding.Exercise
    {
        public static class Helper
        {
            public static int GetGoblinsInGame(Game game)
            {
                int count = 0;
                foreach (Goblin g in game.Creatures)
                    count++;

                return count;
            }

            public static int GetGoblinKingInGame(Game game)
            {
                foreach (Goblin g in (game.Creatures))
                    if (g.ImAking == true)
                        return 1;
                return 0;
            }
        }

        public abstract class Creature
        {
            public int Attack { get; set; }
            public int Defense { get; set; }
            public CreatureModifier CreatureModifier { get; set; }
        }

        public class Goblin : Creature
        {
            public bool ImAking;

            public Goblin(Game game)
            {
                CreatureModifier = new CreatureModifier(this);
                Attack = 1;
                Defense = 1;

                for (int i = 0; i < Helper.GetGoblinsInGame(game); i++)
                {
                    CreatureModifier.Add(new GoblinsInGameModifier(game.Creatures[i]));
                    CreatureModifier.Add(new GoblinsInGameModifier(this));
                }
            }

            public override string ToString()
            {
                return $"{nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class GoblinKing : Goblin
        {
            public GoblinKing(Game game) : base(game)
            {
                Attack = 3;
                Defense = 3;
                ImAking = true;

                for (int i = 0; i < Helper.GetGoblinsInGame(game); i++)
                {
                    CreatureModifier.Add(new GoblinKingInGameModifier(game.Creatures[i]));
                    CreatureModifier.Add(new GoblinKingInGameModifier(this));
                }
            }

            public override string ToString()
            {
                return $"{nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class Game
        {
            public IList<Creature> Creatures = new List<Creature>();
        }

        public class CreatureModifier
        {
            protected Creature creature;
            protected CreatureModifier next;

            public CreatureModifier(Creature creature)
            {
                this.creature = creature;
            }

            public void Add(CreatureModifier cm)
            {
                if (next != null) next.Add(cm);
                else next = cm;
            }

            public virtual void Handle() => next?.Handle();
        }

        public class GoblinKingInGameModifier : CreatureModifier
        {
            public GoblinKingInGameModifier(Creature creature) : base(creature)
            {
                Handle();
            }

            public override void Handle()
            {
                if (creature is GoblinKing == false)
                {
                    creature.Attack++;
                    base.Handle();
                }
            }
        }

        public class GoblinsInGameModifier : CreatureModifier
        {
            public GoblinsInGameModifier(Creature creature) : base(creature)
            {
                Handle();
            }

            public override void Handle()
            {
                creature.Defense++;
                base.Handle();
            }
        }


        public class Demo
        {
            public static void Main(string[] args)
            {
                var game = new Game();

                var goblin = new Goblin(game);
                game.Creatures.Add(goblin);

                var goblin2 = new Goblin(game);
                game.Creatures.Add(goblin2);

                var goblin3 = new Goblin(game);
                game.Creatures.Add(goblin3);

                var goblinKing = new GoblinKing(game);
                game.Creatures.Add(goblinKing);

                
                Console.ReadKey();
            }
        }
    }
}
