using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// The motivation is that the Mediator is a component that facilitates communication
/// between other components without them necessarily being aware of each other or 
/// having direct (reference) access to each other.
/// 
/// It can be used in MMORPG's (online games) that users and players come and 
/// go all the time.
/// Or also in a chat room where users go online and offline all the time.
/// </summary>
namespace Mediator
{
    using static System.Console;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    namespace Coding.Exercise
    {
        public class Participant
        {
            public int Id { get; }

            public int Value { get; set; }
 
            public Mediator Room;

            public Participant(Mediator mediator)
            {
                Value = 0;

                Random rnd = new Random(DateTime.Now.Millisecond);
                Id = rnd.Next(10);
                mediator.Join(this);
            }

            public void Receive(int newValue)
            {
                Value += newValue;
                WriteLine($"Now Participant {this.Id} have Value of {this.Value} in hands");
            }

            public void Say(int n)
            {
                string message = $"Participant {this.Id} said {n}\n";
                Write(message);
                Room.Broadcast(n, this);
            }
        }

        public class Mediator
        {
            private List<Participant> people = new List<Participant>();

            public void Broadcast(int n, Participant part)
            {
                WriteLine("---------We now have updated values---------");

                foreach (var p in people.Where(p => p.Id != part.Id))
                {
                    p.Receive(n);
                }

            }

            public void Join(Participant p)
            {
                string joinMsg = $"Participant {p.Id} joins with value {p.Value} in hands\n";
                Write(joinMsg);
                p.Room = this;
                people.Add(p);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var room = new Mediator();

                var john = new Participant(room);
                var jane = new Participant(room);
 
                john.Say(3);
                jane.Say(2);
            }
        }
    }
}
