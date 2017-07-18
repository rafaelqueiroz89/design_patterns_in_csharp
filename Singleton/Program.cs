using System; 

namespace Singleton
{
    /// <summary>
    /// For some components it only makes sense to have one in the system like a database repository
    /// Want to prevent anyone creating additional copies of the object
    /// Thread safety, the constructor doesn't execute twice and this avoids race condition.
    /// Component instantied just once
    /// 
    /// Singleton is said to be a bad idea because: when singleton is used you might have to use the same object lots of times
    /// 
    /// </summary>
    class Program
    {
        //this class verifies if a determined object is Singleton or not
        public class SingletonTester
        {
            private static object instance;
            
            public static bool IsSingleton(Func<object> func)
            {
                object test = func.Invoke();

                if (Object.ReferenceEquals(test, func.Invoke()))
                    return true;

                return false;       
            }
        }
    }
}