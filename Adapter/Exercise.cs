using System;

/// <summary>
/// Determine the API you have and the API you need
/// Create a component which aggregates the adapter, like extending an Interface
/// Intermediante representations: use caching and other optimizations
/// </summary> 
namespace Coding.Exercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        public Square square;
        public int Width => square.Side;
        public int Height => square.Side;

        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
            square.Side = Width;
        }
    }
}