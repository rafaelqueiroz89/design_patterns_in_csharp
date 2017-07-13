using System;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Ordinary C# statement are perishable! Cannot undo a field/property assignment
/// Uses: GUI commands, multi-level undo-redo, macro recording and more.
/// Fairly used in the financial system where one needs to redo transactions all the time
/// 
/// Encapsulate all details of an operation in a separate object
/// Define instruction for applying the command (either in the command itself, or elsewhere)
/// Optionall define instructions for undoing the command
/// Can composite commands (AKA MACROS !!!!1)
/// </summary>
namespace Command
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    c.Success = true;
                    Balance += c.Amount;
                    break;

                case Command.Action.Withdraw:
                    if (c.Amount <= Balance)
                    {
                        Balance -= c.Amount;
                        c.Success = true;
                    }
                    c.Success = false;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Balance)} : R$ {Balance}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account ac = new Account();
           
            Command command = new Command();
            command.Amount = 100;
            command.TheAction = Command.Action.Deposit;

            ac.Process(command);

            command.TheAction = Command.Action.Withdraw;
            ac.Process(command);

            WriteLine(ac);
        }
    }
}
