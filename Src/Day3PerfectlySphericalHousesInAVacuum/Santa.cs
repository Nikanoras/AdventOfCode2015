using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3PerfectlySphericalHousesInAVacuum
{
    internal sealed class Santa
    {
        private readonly HashSet<House> visitedHouses = new HashSet<House>();
        private Location currentLocation = new Location(0, 0);

        internal Santa()
        {
            visitedHouses.Add(House.StartingHouse);
        }

        internal int NumberOfHousesVisistedAtleastOnce => visitedHouses.Count;
        internal IReadOnlyList<House> VisitedHouses => visitedHouses.ToList();

        internal void VisitNextHouse(char direction)
        {
            Location nextHouseLocation = GetNextHouseCoordinates(direction);
            
            currentLocation = nextHouseLocation;

            var house = new House(currentLocation);
            visitedHouses.Add(house);
        }
        private Location GetNextHouseCoordinates(char direction)
        {
            return direction switch
            {
                '<' => new Location(currentLocation.X - 1, currentLocation.Y),
                '>' => new Location(currentLocation.X + 1, currentLocation.Y),
                'v' => new Location(currentLocation.X, currentLocation.Y - 1),
                '^' => new Location(currentLocation.X, currentLocation.Y + 1),
                _ => throw new ArgumentException("Invalid direction"),
            };
        }
    }
}