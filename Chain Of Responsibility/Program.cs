using static System.Console;
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
    namespace Coding.Exercise
    {
        public abstract class Creature
        {
            public int Attack { get; set; }
            public int Defense { get; set; }
            public CreatureModifier CreatureModifier { get; set; }
        }

        public class Goblin : Creature
        {
            public Goblin(Game game)
            {
                CreatureModifier = new CreatureModifier(this);
                Attack = 1;
                Defense = 1;

                for (int i = 0; i < game.Creatures.Count; i++)
                {
                    CreatureModifier.Add(new GoblinsInGameModifier(game.Creatures[i]));
                    CreatureModifier.Add(new GoblinsInGameModifier(this));
                }
            }

            public override string ToString()
            {
                return $"{nameof(Goblin)}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class GoblinKing : Goblin
        {
            public GoblinKing(Game game) : base(game)
            {
                Attack = 3;
                Defense = 3;

                for (int i = 0; i < game.Creatures.Count; i++)
                {
                    CreatureModifier.Add(new GoblinKingInGameModifier(game.Creatures[i]));
                    CreatureModifier.Add(new GoblinKingInGameModifier(this));
                }
            }

            public override string ToString()
            {
                return $"{nameof(GoblinKing)}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class Game
        {
            public IList<Creature> Creatures;

            public Game()
            {
                Creatures = new Creatures(this);
            }
        }

        public class Creatures : Collection<Creature>
        {
            private Game game;

            public Creatures(Game game)
            {
                this.game = game;
            }

            //no need for this but it is a good exercise to know that you can override the IList with a Collection
            protected override void InsertItem(int index, Creature creature)
            {
                base.InsertItem(index, creature);
            }
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
                if (creature is GoblinKing == false)
                {
                    creature.Defense++;
                    base.Handle();
                }
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

                var goblinKing2 = new GoblinKing(game);
                game.Creatures.Add(goblinKing2);

                WriteLine($"{goblin}");
                WriteLine($"{goblin2}");
                WriteLine($"{goblin3}");
                WriteLine($"{goblinKing}");
                WriteLine($"{goblinKing2}");
                ReadKey();
            }
        }
    }
}

