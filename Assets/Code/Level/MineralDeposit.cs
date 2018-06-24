using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Code.Ship;
using UnityEngine;

namespace Code.Level
{
    public class MineralDeposit : MonoBehaviour
    {
        public Mineral MineralColor;
        public float MaxYield;
        public float MinYield;
        public Light Light;
        public ParticleSystem DustParticle;
        
        public GameObject[] Crystals;

        private float currentYield;
        private float yieldPerCrystal;
        private AudioSource RubbleSfx;
        private bool playSounds;

        void Start()
        {
            RubbleSfx = GetComponent<AudioSource>();
            CalculateCurrentYield();
        }

        void CalculateCurrentYield()
        {
            yieldPerCrystal = MaxYield / Crystals.Length;
            currentYield = Random.Range(MinYield, MaxYield);
            UpdateCrystals();
            playSounds = true;
        }

        void RemoveCrystal()
        {
            Crystals.Last(x => x.activeInHierarchy).SetActive(false);
            
            if (Crystals.All(x => !x.activeInHierarchy))
            {
                Light.enabled = false;
            }

            if (playSounds)
            {
                RubbleSfx.Play();
                DustParticle.Play();
            }
        }

        void UpdateCrystals()
        {
            if (Crystals.Count(x => x.activeInHierarchy) > currentYield / yieldPerCrystal)
            {
                RemoveCrystal();
                UpdateCrystals();
            }
        }

        public MineralYield Mine(float mineStrength)
        {
            var amountMined = currentYield > mineStrength ? mineStrength : currentYield;
            currentYield -= amountMined;
            if (currentYield < 0)
            {
                currentYield = 0;
            }

            UpdateCrystals();

            return new MineralYield(MineralColor, amountMined);
        }
    }
}
