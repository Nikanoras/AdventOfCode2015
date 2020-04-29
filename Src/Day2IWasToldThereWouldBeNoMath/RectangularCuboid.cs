using System.Linq;

namespace Day2IWasToldThereWouldBeNoMath
{
    internal abstract class RectangularCuboid
    {
        private const int NumberOfOppositeSides = 2;

        internal protected RectangularCuboid(decimal length, decimal width, decimal height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private decimal Length { get; }
        private decimal Width { get; }
        private decimal Height { get; }

        private decimal TopOrBottomSideArea => Length * Width;
        private decimal FrontOrBackSideArea => Width * Height;
        private decimal LeftOrRightSideArea => Height * Length;
        private decimal TopOrBottomSidePerimeter => 2 * (Length + Width);
        private decimal FrontOrBackSidePerimeter => 2 * (Width + Height);
        private decimal LeftOrRightSidePerimeter => 2 * (Height + Length);

        internal protected decimal SurfaceArea => NumberOfOppositeSides * (TopOrBottomSideArea + FrontOrBackSideArea + LeftOrRightSideArea);
        internal protected decimal Volume => Length * Width * Height;

        internal protected decimal GetSmallestSideArea()
        {
            decimal smallestSideArea = GetLowestValue(TopOrBottomSideArea, FrontOrBackSideArea, LeftOrRightSideArea);

            return smallestSideArea;
        }
        internal protected decimal GetSmallestSidePerimeter()
        {
            decimal smallestSidePerimeter = GetLowestValue(TopOrBottomSidePerimeter, FrontOrBackSidePerimeter, LeftOrRightSidePerimeter);

            return smallestSidePerimeter;
        }

        private decimal GetLowestValue(params decimal[] values)
        {
            return values.Min();
        }
    }
}
