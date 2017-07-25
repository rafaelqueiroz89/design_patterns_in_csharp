using System;
using static System.Console;

/// <summary>
/// You can use the Observer Pattern when you need to be informed when certain things
/// happen. Like a property change of an object, or when an object does something or when some
/// external events occurs.
/// Built in C# with the 'event' keyword !
/// </summary>
namespace Observer
{
    public class Game
    {
        public event EventHandler RatEnters, RatDies;
        public event EventHandler<Rat> NotifyRat;

        public void FireRatEnters(object sender)
        {
            RatEnters?.Invoke(sender, EventArgs.Empty);
        }

        public void FireRatDies(object sender)
        {
            RatDies?.Invoke(sender, EventArgs.Empty);
        }

        public void FireNotifyRat(object sender, Rat whichRat)
        {
            NotifyRat?.Invoke(sender, whichRat);
        }
    }

    public class Rat : IDisposable
    {
        public int Attack = 1;
        private readonly Game game;

        public Rat(Game game)
        {
            this.game = game;

            game.RatEnters += Game_RatEnters;
            game.NotifyRat += Game_NotifyRat;
            game.RatDies += Game_RatDies;
            game.FireRatEnters(this);
        }

        private void Game_NotifyRat(object sender, Rat e)
        {
            if (e == this)
                e.Attack++;
        }

        private void Game_RatEnters(object sender, EventArgs e)
        {
            if (sender != this)
            {
                Attack++;
                game.FireNotifyRat(this, (Rat)sender);
            }
        }

        private void Game_RatDies(object sender, EventArgs e)
        {
            Attack--;
        }

        public void Dispose()
        {
            game.FireRatDies(this);
        }
    }

    public class MainS
    {
        public static void Main()
        {
            Game game = new Game();
 
            Rat rat = new Rat(game);
            Rat rat2 = new Rat(game);
            Rat rat3 = new Rat(game);

            WriteLine($"Rat1 attack {rat.Attack}");
            WriteLine($"Rat2 attack {rat2.Attack}");
            WriteLine($"Rat3 attack {rat3.Attack}"); //should be 3
            rat.Dispose();
            WriteLine($"\nRat2 attack {rat2.Attack}");
            WriteLine($"Rat3 attack {rat3.Attack}"); //should be 2
        }
    }
}
