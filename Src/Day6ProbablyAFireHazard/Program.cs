using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day6ProbablyAFireHazard
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            //string[] input = { "turn on 0,0 through 999,999" };
            var lights = new Lights();
            foreach (var item in input)
            {
                Instruction instruction = GetInstruction(item);
                lights.ChangeLights(instruction);
            }

            Console.WriteLine(lights.GetCountOfLitLights());
        }

        private static Instruction GetInstruction(string item)
        {
            string action = Regex.Match(item, @"^.*?(?=[0-9])").Value.Trim();
            string[] matches = Regex.Matches(item, @"[0-9]+[,0-9]*").Select(c => c.Value).ToArray();
            string[] coordiantes = string.Join(',', matches).Split(',');
            var fromCoordaintes = new Coordianates(int.Parse(coordiantes[0]), int.Parse(coordiantes[1]));
            var toCoordinates = new Coordianates(int.Parse(coordiantes[2]), int.Parse(coordiantes[3]));
            return new Instruction(GetAction(action), fromCoordaintes, toCoordinates);
        }

        internal static Action GetAction(string action)
        {
            switch (action)
            {
                case "turn off":
                    return Action.TurnOff;
                case "turn on":
                    return Action.TurnOn;
                case "toggle":
                    return Action.Toggle;
                default:
                    throw new ArgumentException("Invalid argument", nameof(action));
            }
        }
    }
}
