using static System.Console;

/// <summary>
/// An object can change. Like a bank account that gets deposits and withdraws.
/// There are different ways of navigating those changes
/// One way is to record every change (Command Pattern) and teach a command to 'undo itself'.
/// Another is to simply save snapshots of the system
/// 
/// A token/handle representing the system state. Let us roll back
/// to the state when the token was
/// generated. May or may not direclty expose state information.
/// 
/// Used to implement undo/redo of an object (pretty good)
/// </summary>
namespace DotNetDesignPatternDemos.Behavioral.Memento
{
    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        private int balance;

        public BankAccount(int balance)
        {
            this.balance = balance;
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            return new Memento(balance);
        }

        public void Restore(Memento m)
        {
            balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public class Demo
    {
        //static void Main(string[] args)
        //{
        //    var ba = new BankAccount(100);
        //    var m1 = ba.Deposit(50); // 150
        //    var m2 = ba.Deposit(25); // 175
        //    WriteLine(ba);

        //    restore to m1
        //    ba.Restore(m1);
        //    WriteLine(ba);

        //    ba.Restore(m2);
        //    WriteLine(ba);
        //}
    }
}