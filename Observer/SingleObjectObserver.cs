using System.ComponentModel;
using static System.Console;

namespace Observer
{
    /// <summary>
    /// You can use the Observer Pattern when you need to be informed when certain things
    /// happen. Like a property change of an object, or when an object does something or when some
    /// external events occurs.
    /// Built in C# with the 'event' keyword !
    /// </summary>
    /// 

    public class Market : INotifyPropertyChanged
    {
        private float volatility;

        public float Volatility
        { 
            get => volatility;
            set
            {
                if (value.Equals(volatility)) return;
                volatility = value;
                OnPropertyChanged(nameof(Volatility));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"The Volatility of the Market is now:  { Volatility }";
        }
    }

    public class SingleObjectObserver
    {
        //public static void Main()
        //{
        //    var market = new Market();
            
        //    //it will come back to this event when the Volatility of the Market changes. We first need to
        //    // subscribe the event and then change its property
        //    market.PropertyChanged += (sender, eventArgs) =>
        //    {
        //        if (eventArgs.PropertyName == nameof(market.Volatility))
        //        {
        //            WriteLine(market.ToString());
        //        }
        //    };

        //    market.Volatility = 1;
        //    market.Volatility = 2;
        //}
    }
}
