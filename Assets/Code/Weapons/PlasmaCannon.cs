using System.Collections;
using Code.Movement;
using UnityEngine;

namespace Code.Weapons
{
    public class PlasmaCannon : MonoBehaviour
    {
        public ParticleSystem[] FirePositions;
        public BarrelKick[] Barrels;
        public GameObject PlasmaBallPf;
        public float RateOfFire;

        private int barrelIndex = 0;
        private bool isCycling;
        private TurretMovement turret;

        void Start()
        {
            turret = GetComponentInParent<TurretMovement>();
        }

        public void Fire()
        {
            if (!isCycling && turret.enabled)
            {
                Instantiate(PlasmaBallPf, FirePositions[barrelIndex].transform.position, transform.rotation);
                FirePositions[barrelIndex].Play();
                Barrels[barrelIndex].Kick();
                CycleBarrel();
                StartCoroutine(CycleAmmo());
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

            if (barrelIndex >= FirePositions.Length)
            {
                barrelIndex = 0;
            }
        }
    }
}
