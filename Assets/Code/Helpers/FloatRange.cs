using System;

namespace Code.Helpers
{
    [Serializable]
    public struct FloatRange
    {
        public float MinValue;
        public float MaxValue;

        public FloatRange(float min, float max)
        {
            max = min > max ? min + 1 : max;

            MinValue = min;
            MaxValue = max;
        }
    }
}
