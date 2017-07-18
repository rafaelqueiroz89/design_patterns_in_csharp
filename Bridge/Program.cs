using System;
using static System.Console;

/// <summary>
/// A mechanism that decouples an interface (hierarchy) from an implementation
/// (hierachy)
/// Decouple abstraction
/// Bridge between the domain object and how this object should be processed
/// </summary>

namespace Coding.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        private IRenderer renderer;

        public string Name
        { get; set; }

        // a bridge between the shape that's being drawn an
        // the component which actually draws it
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string Name;
        public string WhatToRenderAs { get => "lines"; }
    }

    public class RasterRenderer : IRenderer
    {
        public string Name;
        public string WhatToRenderAs { get => "pixels"; }
    }

    public class Triangle : Shape
    {
        string Aswhat;
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
            Aswhat = renderer.WhatToRenderAs;
        }

        public override string ToString() => $"Drawing {Name} as {Aswhat}";
    }

    public class Square : Shape
    {
        string Aswhat;
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
            Aswhat = renderer.WhatToRenderAs;
        }

        public override string ToString() => $"Drawing {Name} as {Aswhat}";
    }

    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine(new Square(new VectorRenderer()).ToString());   // returns "Drawing Square as lines"
            WriteLine(new Triangle(new RasterRenderer()).ToString());   // returns "Drawing Triangle as pixels"
        }
    }
}
