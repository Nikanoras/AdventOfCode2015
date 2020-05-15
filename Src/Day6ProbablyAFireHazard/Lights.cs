using System.Collections.Generic;
using System.Linq;

namespace Day6ProbablyAFireHazard
{
    internal sealed class Lights
    {
        private readonly int[][] _grid = new int[1000][];

        public Lights()
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                _grid[i] = new int[1000];
            }
        }

        internal void ChangeLights(Instruction instruction)
        {
            int lightsStatus = (int)instruction.Action;
            for (int row = 0; row < _grid[0].Length; row++)
            {
                if (row < instruction.From.X || row > instruction.ToCoordinates.X)
                    continue;
                for (int column = 0; column < _grid[1].Length; column++)
                {
                    if (column < instruction.From.Y || column > instruction.ToCoordinates.Y)
                        continue;

                    if ((int)Action.Toggle == lightsStatus)
                        _grid[row][column] = _grid[row][column] == 0 ? (int)Action.TurnOn : (int)Action.TurnOff;
                    else
                        _grid[row][column] = lightsStatus;
                }
            }
        }

        internal int GetCountOfLitLights()
        {
            IEnumerable<int> x = _grid.SelectMany(l => l);
            return x.Count(l => l == (int)Action.TurnOn);
        }
    }
}
