namespace Day6ProbablyAFireHazard
{
    class Instruction
    {
        public Instruction(Action action, Coordianates from, Coordianates toCoordinates)
        {
            Action = action;
            From = from;
            ToCoordinates = toCoordinates;
        }

        public Action Action { get; private set; }
        public Coordianates From { get; private set; }
        public Coordianates ToCoordinates { get; private set; }
    }
}
