using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day6ProbablyAFireHazard
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            string[] values = File.ReadAllLines("input.txt");
            
            // --- Part One ---
            var simpleGarland = new SimpleGarland();
            foreach (var value in values)
            {
                Instruction instruction = GetInstruction(value);
                simpleGarland.SwitchLights(instruction);
            }
            Console.WriteLine(simpleGarland.GetCountOfLightsLit());

            // --- Part Two ---
            var adjustableBrightnessGarland = new AdjustableBrightnessGarland();
            foreach (var value in values)
            {
                Instruction instruction = GetInstruction(value);
                adjustableBrightnessGarland.IncreaseBrightness(instruction);
            }
            Console.WriteLine(adjustableBrightnessGarland.GetTotalBrightness());
        }
        private static Action GetAction(string action)
        {
            return action switch
            {
                "turn off" => Action.TurnOff,
                "turn on" => Action.TurnOn,
                "toggle" => Action.Toggle,
                _ => throw new ArgumentException("Invalid argument", nameof(action)),
            };
        }
        private static Instruction GetInstruction(string value)
        {
            string action = Regex.Match(value, @"^.*?(?=[0-9])").Value.Trim();
            string[] matches = Regex.Matches(value, @"[0-9]+[,0-9]*").Select(c => c.Value).ToArray();
            string[] coordiantes = string.Join(',', matches).Split(',');
            var fromCoordaintes = new LightCoordianates(int.Parse(coordiantes[0]), int.Parse(coordiantes[1]));
            var toCoordinates = new LightCoordianates(int.Parse(coordiantes[2]), int.Parse(coordiantes[3]));
            return new Instruction(GetAction(action), fromCoordaintes, toCoordinates);
        }
    }
}
