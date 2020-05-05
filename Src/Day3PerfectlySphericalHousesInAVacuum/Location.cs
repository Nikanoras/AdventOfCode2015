namespace Day3PerfectlySphericalHousesInAVacuum
{
    internal class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }
        public bool Equals(Location other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return (X == other.X) && (Y == other.Y);
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() * 17 + Y.GetHashCode();
        }
    }
}
