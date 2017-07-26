using System;
using static System.Console;
using System.Numerics;

/// <summary>
/// Many algorithms can be decomposed into higher and lower level parts
/// 
/// Making a tea can be decomposed into:
/// - The process of making a hot beverage (boil water, pour into cup);
/// - Tea-specific things (put teabag into water)
/// 
/// The High-level algorithm can then be reused for making coffee or hot chocolate
/// - Supported by beverage-specific strategies
/// 
/// So the Strategy pattern enables the exact behavior of a system to be selected either at runtime (dynamic)
/// or compile-time (static)
/// 
/// Also known as "policy" (like in C++ world and other languages)
/// </summary>
namespace Strategy
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo (return NaN on negative discriminant!)
        public double CalculateDiscriminant(double a, double b, double c)
        {
            double result = b * b - 4 * a * c;

            if (result >= 0)
                return result;
            else
                return double.NaN;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var disc = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);
            var rootDisc = Complex.Sqrt(disc);

            return Tuple.Create(
              (-b + rootDisc) / (2 * a),
              (-b - rootDisc) / (2 * a)
            );
        }
    }

    public class Exercise
    {
        public static void Main()
        {
            var strategy = new OrdinaryDiscriminantStrategy();
            var solver = new QuadraticEquationSolver(strategy);
            var results = solver.Solve(1, 10, 16);
            WriteLine($"Item 1: {results.Item1}"); //Assert.That(results.Item1, Is.EqualTo(new Complex(-2, 0)));
            WriteLine($"Item 2: {results.Item2}"); //Assert.That(results.Item2, Is.EqualTo(new Complex(-8, 0)));

            results = solver.Solve(1, 4, 5);
            var complexNaN = new Complex(double.NaN, double.NaN);

            WriteLine($"Item 1: {results.Item1}");
            /*Assert.That(results.Item1, Is.EqualTo(complexNaN));
             * Assert.IsTrue(double.IsNaN(results.Item1.Real));
             * Assert.IsTrue(double.IsNaN(results.Item1.Imaginary));
            */
            WriteLine($"Item 2: {results.Item2}");
            /*Assert.That(results.Item2, Is.EqualTo(complexNaN));
             * Assert.IsTrue(double.IsNaN(results.Item2.Real));
             * Assert.IsTrue(double.IsNaN(results.Item2.Imaginary));
             */
        }
    }
}
