namespace Day1NotQuiteLisp
{
    internal sealed class SantaFloorNavigator
    {
        private readonly char[] _directions;

        internal SantaFloorNavigator(char[] directions)
        {
            _directions = directions;
        }

        internal int GetFinalDestination()
        {
            var currentSantasFloor = 0;
            foreach (char direction in _directions)
            {
                currentSantasFloor += GetNextSantasDirection(direction);
            }

            return currentSantasFloor;
        }

        internal int GetPositionOfFirstDirectionForSantaToVisitBasement()
        {
            var currentSantasFloor = 0;
            for (int i = 0; i < _directions.Length; i++)
            {
                currentSantasFloor += GetNextSantasDirection(_directions[i]);
                if (IsBasement(currentSantasFloor))
                    return i + 1;
            }
            return 0;

            static bool IsBasement(int currentFloor)
            {
                return currentFloor == -1;
            }
        }

        private static int GetNextSantasDirection(char direction)
        {
            if (IsUpstairs(direction))
                return 1;
            else if (IsDownstairs(direction))
                return -1;
            return 0;

            static bool IsUpstairs(char direction)
            {
                return direction == '(';
            }

            static bool IsDownstairs(char direction)
            {
                return direction == ')';
            }
        }
    }
}
