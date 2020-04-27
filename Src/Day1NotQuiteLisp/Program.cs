using System;
using System.IO;

namespace Day1NotQuiteLisp
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] directions = File.ReadAllText("input.txt").ToCharArray();

            var floorNavigator = new SantaFloorNavigator(directions);

            int floor = floorNavigator.GetFinalDestination();

            Console.WriteLine($"The santa finally reached his destination at floor: {floor}!");

            int firstBasementVisitDirectionPosition = floorNavigator.GetPositionOfFirstDirectionForSantaToVisitBasement();

            Console.WriteLine($"Very interesting fact: The santa visited basement for the first time on direction number: {firstBasementVisitDirectionPosition}!");
        }
    }
}
