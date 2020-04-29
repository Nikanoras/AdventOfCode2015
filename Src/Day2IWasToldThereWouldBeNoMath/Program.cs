using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2IWasToldThereWouldBeNoMath
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            
            IEnumerable<PresentBox> boxes = input.Select(x => PresentBox.ParseFrom(x));

            var calculator = new PresentWrappingMaterialCalculator(boxes);

            decimal requiredWrappingPaper = calculator.GetRequiredSquareFeetOfWrappingPaper();
            
            Console.WriteLine(requiredWrappingPaper);

            decimal requiredRibbon = calculator.GetRequiredFeetOfRibbon();

            Console.WriteLine(requiredRibbon);
        }
    }
}
