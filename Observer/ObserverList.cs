using System;
using System.ComponentModel;

/// <summary>
/// You can use the Observer Pattern when you need to be informed when certain things
/// happen. Like a property change of an object, or when an object does something or when some
/// external events occurs.
/// Built in C# with the 'event' keyword !
/// </summary>
 
namespace RxDemos
{
    public class Market
    {
        //    public List<float> Prices = new List<float>();
        //
        public void AddPrice(float price)
        {
            Prices.Add(price);
            //PriceAdded?.Invoke(this, new PriceAddedEventArgs{ Price = price});
        }
        //
        //    public event EventHandler<PriceAddedEventArgs> PriceAdded;
        public BindingList<float> Prices = new BindingList<float>();
    }

    public class PriceAddedEventArgs
    {
        public float Price;
    }

    public class ObserverPattern
    {
        //static void Main(string[] args)
        //{
        //    Market market = new Market();
        //    //      market.PriceAdded += (sender, eventArgs) =>
        //    //      {
        //    //        Console.WriteLine($"Added price {eventArgs.Price}");
        //    //      };
        //    //      market.AddPrice(123);
        //    market.Prices.ListChanged += (sender, eventArgs) => // Subscribe
        //    {
        //        if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
        //        {
        //            Console.WriteLine($"Added price {((BindingList<float>)sender)[eventArgs.NewIndex]}");
        //        }
        //    };
        //    market.AddPrice(123);
        //    // 1) How do we know when a new item becomes available?

        //    // 2) how do we know when the market is done supplying items?
        //    // maybe you are trading a futures contract that expired and there will be no more prices

        //    // 3) What happens if the market feed is broken?

        //}
    }
}