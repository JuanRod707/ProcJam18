using System.Collections.Generic;
using Code.Common;
using Code.Helpers;
using Code.Level;

namespace Code.ControlRoom
{
    public class MiningMission : Mission
    {
        private Mineral targetMineral;
        private float targetAmount;

        public string Description {
            get { return string.Format("Extract {0:0.0} units of {1}", targetAmount, GameConfiguration.MineralDisplay[targetMineral]); }
        }

        public int Reward
        {
            get
            {
                return (int) (GameConfiguration.MineralValues[targetMineral] * targetAmount *
                              GameConfiguration.ExtractionMissionMultiplier);
            }
        }

        public bool IsComplete { get; private set; }

        public MiningMission(IEnumerable<Mineral> possibleMinerals)
        {
            targetMineral = possibleMinerals.PickOne();
            targetAmount = MathHelper.SelectFromRange(GameConfiguration.MineralExtractionRange);
        }

        public void CheckCompletion()
        {
            IsComplete = GlobalReferences.CargoBay.Contains(targetMineral) >= targetAmount;
            if (IsComplete)
                GlobalReferences.Notifications.DisplayMissionAccomplished();
        }

        public void Complete()
        {
            GlobalReferences.CargoBay.Remove(targetMineral, targetAmount);
        }
    }
}
