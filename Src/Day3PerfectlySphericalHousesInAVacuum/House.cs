using System;
using System.Collections.Generic;

namespace Day3PerfectlySphericalHousesInAVacuum
{
    internal sealed class House
    {
        internal static readonly House StartingHouse = new House(new Location(0, 0));

        private readonly Location location;

        internal House(Location location)
        {
            this.location = location;
        }
        
        public override bool Equals(object obj)
        {
            return obj is House house &&
                   EqualityComparer<Location>.Default.Equals(location, house.location);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(location);
        }
    }
}
