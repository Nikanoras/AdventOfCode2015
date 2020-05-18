namespace Day6ProbablyAFireHazard
{
    internal sealed class Instruction
    {
        internal Instruction(Action action, LightCoordianates lightCoordinatesFrom, LightCoordianates lightCoordinatesTo)
        {
            Action = action;
            LightCoordinatesFrom = lightCoordinatesFrom;
            LightCoordinatesTo = lightCoordinatesTo;
        }

        internal Action Action { get; }
        internal LightCoordianates LightCoordinatesFrom { get; }
        internal LightCoordianates LightCoordinatesTo { get; }
    }
}
