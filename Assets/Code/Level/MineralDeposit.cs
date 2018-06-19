using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            UpdateCrystals();
        }

        void RemoveCrystal()
        {
            Crystals.Last(x => x.activeInHierarchy).SetActive(false);
        }

        void UpdateCrystals()
        {
            if (Crystals.Count(x => x.activeInHierarchy) > currentYield / yieldPerCrystal)
            {
                RemoveCrystal();
                UpdateCrystals();
            }
        }

        public float Mine(float mineStrength)
        {
            var amountMined = currentYield > mineStrength ? mineStrength : currentYield;
            currentYield -= amountMined;
            UpdateCrystals();

            return amountMined;
        }
    }
}
