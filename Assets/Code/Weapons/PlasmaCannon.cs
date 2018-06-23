using System.Collections;
using Code.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Weapons
{
    public class PlasmaCannon : MonoBehaviour
    {
        public ParticleSystem[] MuzzleFlashes;
        public BarrelKick[] Barrels;
        public Transform[] FiringPositions;

        public GameObject PlasmaBallPf;
        public Image EnergyMeter;
        public float RateOfFire;
        public float MaxEnergy;
        public float EnergyFireCost;
        public float EnergyRecovery;

        private float currentEnergy;
        private int barrelIndex = 0;
        private bool isCycling;
        private TurretMovement turret;

        void Start()
        {
            turret = GetComponentInParent<TurretMovement>();
            currentEnergy = MaxEnergy;
        }

        void Update()
        {
            currentEnergy += EnergyRecovery;
            if (currentEnergy > MaxEnergy)
            {
                currentEnergy = MaxEnergy;
            }

            UpdateEnergyMeter();
        }

        private void UpdateEnergyMeter()
        {
            if (EnergyMeter != null)
            {
                EnergyMeter.fillAmount = currentEnergy / MaxEnergy;
            }
        }

        public void Fire()
        {
            if (!isCycling && currentEnergy >= EnergyFireCost && turret.enabled)
            {
                Instantiate(PlasmaBallPf, MuzzleFlashes[barrelIndex].transform.position, transform.rotation);
                MuzzleFlashes[barrelIndex].Play();
                Barrels[barrelIndex].Kick();
                CycleBarrel();
                StartCoroutine(CycleAmmo());
                currentEnergy -= EnergyFireCost;
            }
        }

        IEnumerator CycleAmmo()
        {
            isCycling = true;
            yield return new WaitForSeconds(RateOfFire);
            isCycling = false;
        }

        void CycleBarrel()
        {
            barrelIndex++;

            if (barrelIndex >= MuzzleFlashes.Length)
            {
                barrelIndex = 0;
            }
        }
    }
}
