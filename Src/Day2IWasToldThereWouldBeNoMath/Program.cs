using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Day2IWasToldThereWouldBeNoMath
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = File.ReadAllLines("input.txt");

            IEnumerable<PresentBox> boxes = input.Select(x => PresentBox.ParseFrom(x));

            var calculator = new PresentWrappingMaterialCalculator(boxes);

            decimal requiredWrappingPaper = calculator.GetRequiredSquareFeetOfWrappingPaper();

            Console.WriteLine($"Elves should order {requiredWrappingPaper:F2} feet² of wrapping paper.");

            decimal requiredRibbon = calculator.GetRequiredFeetOfRibbon();

            Console.WriteLine($"Elves should order {requiredRibbon:F2} feet of ribbon.");
        }
    }
}
