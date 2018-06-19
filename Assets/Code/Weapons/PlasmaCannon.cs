using System.Collections;
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
        
        public void Fire()
        {
            if (!isCycling)
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
