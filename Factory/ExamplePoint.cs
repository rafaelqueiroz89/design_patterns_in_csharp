using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
 
    public class Point
    {
        private double x;
        private double y;
        public static Point Origin = new Point(0, 0);
        private static bool isCartesian = false;

        //factory method
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                isCartesian = true;
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            if (isCartesian)
                return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
            else
                return $"{"rho"}: {x}, {"theta"}: {y}";
        }

        //public class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
        //        Console.WriteLine($"Origin of points are always {Point.Origin}\n{point.ToString()}");

        //        var point2 = Point.Factory.NewCartesianPoint(2, 3);
        //        Console.WriteLine($"Origin of points are always {Point.Origin}\n{point2.ToString()}");
        //        Console.ReadKey();
        //    }
        //}
    }
}