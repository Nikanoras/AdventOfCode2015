using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2IWasToldThereWouldBeNoMath
{
    internal sealed class PresentWrappingMaterialCalculator
    {
        private readonly IEnumerable<PresentBox> boxes;

        public PresentWrappingMaterialCalculator(IEnumerable<PresentBox> boxes)
        {
            this.boxes = boxes;
        }

        internal decimal GetRequiredSquareFeetOfWrappingPaper()
        {
            return boxes.Select(b => b.GetRequiredSquareFeetOfWrappingPaper()).Sum();
        }

        internal decimal GetRequiredFeetOfRibbon()
        {
            return boxes.Select(b => b.GetRequiredFeetOfRibbon()).Sum();
        }
    }
}
