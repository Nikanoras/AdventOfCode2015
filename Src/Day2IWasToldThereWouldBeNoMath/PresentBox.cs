using System;
using System.Linq;

namespace Day2IWasToldThereWouldBeNoMath
{
    internal sealed class PresentBox : RectangularCuboid
    {
        public PresentBox(decimal length, decimal width, decimal height) : base(length, width, height)
        {
        }

        public decimal GetRequiredSquareFeetOfWrappingPaper()
        {
            return SurfaceArea + GetSmallestSideArea();
        }
        public decimal GetRequiredFeetOfRibbon()
        {
            return Volume + GetSmallestSidePerimeter();
        }

        internal static PresentBox ParseFrom(string s)
        {
            string[] dimensions = s.Split('x');

            decimal length = decimal.Parse(dimensions[0]);
            decimal width = decimal.Parse(dimensions[1]);
            decimal height = decimal.Parse(dimensions[2]);

            return new PresentBox(length, width, height);
        }
    }
}
