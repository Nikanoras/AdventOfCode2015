using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3PerfectlySphericalHousesInAVacuum
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string directions = File.ReadAllText("input.txt");

            var drunkElf = new DrunkElf(directions);
            var santa = new Santa();
            drunkElf.NavigateSantaToDeliverPresents(santa);

            Console.WriteLine($"This year, with a help of that drunken elf, {santa.NumberOfHousesVisistedAtleastOnce} houses received at least one present.");

            Console.WriteLine("\n~A Year Later....~\n");

            santa = new Santa();
            var roboSanta = new Santa();
            drunkElf.NavigateSantasToDeliverPresents(santa, roboSanta);

            House[] uniqueHousesVisitedByBothSantas = GetUniqueSantasCombinedVisitedHouses(santa, roboSanta).ToArray();

            Console.WriteLine($"That elf got drunk again, ugh...");
            Console.WriteLine($"This time we went with my little helper, Robo-Santa.");
            Console.WriteLine($"This year {uniqueHousesVisitedByBothSantas.Length} houses received at least one present from us both.");
        }

        private static IEnumerable<House> GetUniqueSantasCombinedVisitedHouses(Santa santa, Santa roboSanta)
        {
            return new HashSet<House>(santa.VisitedHouses.Concat(roboSanta.VisitedHouses));
        }
    }
}
