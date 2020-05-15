using System;
using System.IO;

namespace Day5DoesntHeHaveInternElvesForThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = File.ReadAllLines("input.txt");
            //string[] values = { "aabaaa", "aabcdefgaa" };
            StringAnalyzer stringAnalyzer = new StringAnalyzer(values);
            int ridiculousStringCount = stringAnalyzer.GetRediculousNiceStringCount();
            int nicerStringCount = stringAnalyzer.GetNicerStringCount();

            Console.WriteLine($"Santa has {ridiculousStringCount} nice strings in his file");
            Console.WriteLine($"Santa has {nicerStringCount} nicer strings in his file");
        }
    }
}
