namespace Day5DoesntHeHaveInternElvesForThis
{
    internal class StringAnalyzer
    {
        private readonly string[] strings;

        public StringAnalyzer(string[] strings)
        {
            this.strings = strings;
        }

        public int GetRediculousNiceStringCount()
        {
            int count = 0;
            foreach (string value in strings)
            {
                string[] naughtyStrings = { "ab", "cd", "pq", "xy" };
                if (!value.ContainsAnyIgnoreCase(naughtyStrings) && value.HasAtleastCountOfVowelsIgnoreCase(3) && value.HasLetterAppearingTwiceInRowIgnoreCase())
                {
                    count += 1;
                }
            }
            return count;
        }

        public int GetNicerStringCount()
        {
            int count = 0;
            foreach (string value in strings)
            {
                if (value.HasLetterComboAppearingTwiceWithNoOverlapping() && value.Method1())
                {
                    count += 1;
                }
            }
            return count;
        }
    }
}
