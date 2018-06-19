using System.Linq;
using UnityEngine;

namespace Code.Level
{
    public class MineralDeposit : MonoBehaviour
    {
        public Mineral MineralColor;
        public float MaxYield;
        public float MinYield;

        public GameObject[] Crystals;

        private float currentYield;
        private float yieldPerCrystal;

        void Start()
        {
            CalculateCurrentYield();
        }

        void CalculateCurrentYield()
        {
            yieldPerCrystal = MaxYield / Crystals.Length;
            currentYield = Random.Range(MinYield, MaxYield);

            var yieldToLose = MaxYield - currentYield;
            for (int i = 0; i < yieldToLose / yieldPerCrystal; i++)
            {
                RemoveCrystal();
            }
        }

        void RemoveCrystal()
        {
            Crystals.Last(x => x.activeInHierarchy).SetActive(false);
        }
    }
}
