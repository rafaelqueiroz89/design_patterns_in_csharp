using System;
using static System.Console;

/// <summary>
/// It just checks if an object is null and display some warning and everything.
/// Not a GOF design pattern but it is good to use everywhere.
/// </summary>
namespace Null_Object
{
    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }

        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class Account
    {
        private ILog log;

        public Account(ILog log)
        {
            if (this.log == null)
                this.log = log;
        }

        public void SomeOperation()
        {
            int c = log.RecordCount;

            log.LogInfo("Performing an operation");
            if (c + 1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    public class NullLog : ILog
    {
        public int RecordLimit { get; } = int.MaxValue;

        public int RecordCount { get; set; } = int.MinValue;

        public void LogInfo(string message)
        {
            RecordCount++;
            WriteLine(message);
        }
    }
}
