namespace Day6ProbablyAFireHazard
{
    internal sealed class AdjustableBrightnessGarland : Garland
    {
        private int totalBrightness;

        internal void IncreaseBrightness(Instruction instruction)
        {
            for (int row = 0; row < _lightGrid[0].Length; row++)
            {
                if (row < instruction.LightCoordinatesFrom.X || row > instruction.LightCoordinatesTo.X)
                    continue;
                for (int column = 0; column < _lightGrid[1].Length; column++)
                {
                    if (column < instruction.LightCoordinatesFrom.Y || column > instruction.LightCoordinatesTo.Y)
                        continue;

                    switch (instruction.Action)
                    {
                        case Action.TurnOff:
                            int currentLightBrightness = _lightGrid[row][column];
                            if (!IsLightLit(currentLightBrightness))
                                DecreaseBrightnessBy(1);
                            break;
                        case Action.TurnOn:
                            IncreaseBrightnessBy(1);
                            break;
                        case Action.Toggle:
                            IncreaseBrightnessBy(2);
                            break;
                        default:
                            break;
                    }
                }
            }

            void DecreaseBrightnessBy(int val)
            {
                totalBrightness -= val;
            }

            void IncreaseBrightnessBy(int val)
            {
                totalBrightness += val;
            }

            static bool IsLightLit(int currentLightBrightness)
            {
                return currentLightBrightness > 0;
            }
        }

        internal int GetTotalBrightness()
        {
            return totalBrightness;
        }
    }
}
