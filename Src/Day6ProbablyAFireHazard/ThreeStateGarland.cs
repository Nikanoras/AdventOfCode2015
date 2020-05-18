using System.Collections.Generic;
using System.Linq;

namespace Day6ProbablyAFireHazard
{
    internal sealed class ThreeStateGarland : Garland
    {
        internal void SwitchLights(Instruction instruction)
        {
            int lightsStatus = (int)instruction.Action;
            for (int row = 0; row < _lightGrid[0].Length; row++)
            {
                if (row < instruction.LightCoordinatesFrom.X || row > instruction.LightCoordinatesTo.X)
                    continue;
                for (int column = 0; column < _lightGrid[1].Length; column++)
                {
                    if (column < instruction.LightCoordinatesFrom.Y || column > instruction.LightCoordinatesTo.Y)
                        continue;

                    ChangeState(lightsStatus, row, column);
                }
            }
        }
        internal int GetCountOfLightsLit()
        {
            IEnumerable<int> x = _lightGrid.SelectMany(l => l);
            return x.Count(l => l == (int)Action.TurnOn);
        }
        private void ChangeState(int lightsStatus, int row, int column)
        {
            if ((int)Action.Toggle == lightsStatus)
                _lightGrid[row][column] = _lightGrid[row][column] == 0 ? (int)Action.TurnOn : (int)Action.TurnOff;
            else
                _lightGrid[row][column] = lightsStatus;
        }
    }
}
