using System;
using Random = UnityEngine.Random;

namespace Code.Helpers
{
    public static class MathHelper
    {
        public static bool RollD2()
        {
            return Random.Range(0, 2) > 0;
        }

        public static int RollD100()
        {
            return Random.Range(0, 100);
        }

        public static bool ChanceD100(int chance)
        {
            return RollD100() < chance;
        }

        public static void RepeatTimes(Action action, int times)
        {
            while (times > 0)
            {
                action();
                times--;
            }
        }

        public static float SelectFromRange(FloatRange range)
        {
            return Random.Range(range.MinValue, range.MaxValue);
        }

        public static int SelectFromRange(IntRange range)
        {
            return Random.Range(range.MinValue, range.MaxValue);
        }
    }
}
