namespace Day6ProbablyAFireHazard
{
    internal class Garland
    {
        protected int[][] _lightGrid = new int[1000][];

        protected Garland()
        {
            SetLightGridToInitialState();
        }
        
        private void SetLightGridToInitialState()
        {
            for (int i = 0; i < _lightGrid.Length; i++)
                _lightGrid[i] = new int[1000];
        }
    }
}
