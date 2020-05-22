using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7SomeAssemblyRequired
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            //var input = new[] {
            //    "123 -> x",
            //    "456 -> y",
            //    "x AND y -> d",
            //    "x OR y -> e",
            //    "x LSHIFT 2 -> f",
            //    "y RSHIFT 2 -> g",
            //    "NOT x -> h",
            //    "NOT y -> i"
            //};
            var instructions = new Queue<string>(input);

            var wires = new Dictionary<string, ushort>();
            while (instructions.Any())
            {
                string instruction = instructions.Dequeue();
                string id = instruction.Substring(instruction.LastIndexOf(" ") + 1);
                var operands = instruction.Substring(0, instruction.IndexOf(" -")).Split(" ");
                ushort? signal = null;
                if (operands.Length == 1)
                {
                    if (ushort.TryParse(operands[0], out ushort value))
                    {
                        signal = value;
                    }
                    else if (wires.TryGetValue(operands[0], out ushort wireSignal))
                    {
                        signal = wireSignal;
                    }
                }
                else if (operands.Length == 2)
                {
                    if (ushort.TryParse(operands[1], out ushort value))
                    {
                        signal = value;
                    }
                    else if (wires.TryGetValue(operands[1], out ushort val))
                    {
                        signal = (ushort)(short)~val;
                    }
                }
                else if (operands.Length == 3 && (operands[1] == "AND" || operands[1] == "OR"))
                {
                    string firstOperand = operands[0];
                    string operand = operands[1];
                    string secondOperand = operands[2];
                    ushort? firstSignal = null;
                    ushort? secondSignal = null;

                    if (ushort.TryParse(firstOperand, out ushort x) && wires.TryGetValue(secondOperand, out ushort value))
                    {
                        firstSignal = x;
                        secondSignal = value;
                    }
                    else if (wires.TryGetValue(firstOperand, out ushort value1) && ushort.TryParse(secondOperand, out ushort y))
                    {
                        firstSignal = value1;
                        secondSignal = y;
                    }
                    else if (ushort.TryParse(firstOperand, out ushort z) && ushort.TryParse(secondOperand, out ushort w))
                    {
                        firstSignal = z;
                        secondSignal = w;
                    }
                    else if (wires.TryGetValue(firstOperand, out ushort q) && wires.TryGetValue(secondOperand, out ushort t))
                    {
                        firstSignal = q;
                        secondSignal = t;
                    }

                    if (firstSignal.HasValue && secondSignal.HasValue)
                    {
                        if (operand == "AND")
                        {
                            signal = Convert.ToUInt16(firstSignal & secondSignal);
                        }
                        else if (operand == "OR")
                        {
                            signal = Convert.ToUInt16(firstSignal | secondSignal);
                        }
                    }
                }
                else if (operands.Length == 3 && (operands[1] == "LSHIFT" || operands[1] == "RSHIFT"))
                {
                    string firstWireId = operands[0];
                    string operand = operands[1];
                    string shiftBy = operands[2];
                    if (wires.TryGetValue(firstWireId, out ushort firstWireSignal))
                    {
                        if (operand == "LSHIFT")
                        {
                            signal = Convert.ToUInt16(firstWireSignal << ushort.Parse(shiftBy));
                        }
                        else if (operand == "RSHIFT")
                        {
                            signal = Convert.ToUInt16(firstWireSignal >> ushort.Parse(shiftBy));
                        }
                    }
                }

                if (signal.HasValue)
                    wires.Add(id, signal.Value);
                else
                    instructions.Enqueue(instruction);
            }
            Console.WriteLine(wires.FirstOrDefault(w => w.Key?.ToLower() == "a").Value);
        }
    }
}
