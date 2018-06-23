namespace Code.Helpers
{
    public struct IntRange
    {
        public int MinValue;
        public int MaxValue;

        public IntRange(int min, int max)
        {
            max = min > max ? min + 1 : max;

            MinValue = min;
            MaxValue = max;
        }
    }
}
