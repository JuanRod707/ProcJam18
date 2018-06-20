using Code.Level;

namespace Code.Ship
{
    public struct MineralYield
    {
        public Mineral Mineral;
        public float Amount;

        public MineralYield(Mineral mineral, float amount)
        {
            Mineral = mineral;
            Amount = amount;
        }
    }
}
