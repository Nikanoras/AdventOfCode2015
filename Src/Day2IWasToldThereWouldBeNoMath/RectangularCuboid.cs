using System.Linq;

namespace Day2IWasToldThereWouldBeNoMath
{
    public abstract class RectangularCuboid
    {
        private const int NumberOfOppositeSides = 2;

        protected RectangularCuboid(decimal length, decimal width, decimal height)
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

        protected decimal SurfaceArea => NumberOfOppositeSides * (TopOrBottomSideArea + FrontOrBackSideArea + LeftOrRightSideArea);

        protected decimal TopOrBottomSidePerimeter => 2 * (Length + Width);
        protected decimal FrontOrBackSidePerimeter => 2 * (Width + Height);
        protected decimal LeftOrRightSidePerimeter => 2 * (Height + Length);

        protected decimal Volume => Length * Width * Height;

        protected decimal GetSmallestSideArea()
        {
            decimal[] sideAreas = { TopOrBottomSideArea, FrontOrBackSideArea, LeftOrRightSideArea };

            decimal smallestSideArea = sideAreas.Min();

            return smallestSideArea;
        }

        protected decimal GetSmallestSidePerimeter()
        {
            decimal[] sideAreas = { TopOrBottomSidePerimeter, FrontOrBackSidePerimeter, LeftOrRightSidePerimeter };

            decimal smallestSideArea = sideAreas.Min();

            return smallestSideArea;
        }
    }
}
