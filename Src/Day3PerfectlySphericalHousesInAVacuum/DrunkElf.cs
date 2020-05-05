namespace Day3PerfectlySphericalHousesInAVacuum
{
    internal sealed class DrunkElf
    {
        private readonly string directions;

        internal DrunkElf(string directions)
        {
            this.directions = directions;
        }

        internal void NavigateSantaToDeliverPresents(Santa santa)
        {
            foreach (char direction in directions)
            {
                santa.VisitNextHouse(direction);
            }
        }
        internal void NavigateSantasToDeliverPresents(Santa santa, Santa roboSanta)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                char direction = directions[i];
                if (IsSantasTurn(i))
                    santa.VisitNextHouse(direction);
                else
                    roboSanta.VisitNextHouse(direction);
            }

            static bool IsSantasTurn(int turn)
            {
                return turn % 2 == 0;
            }
        }
    }
}
