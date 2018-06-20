using System.Collections;
using Code.Level;
using Code.Movement;
using UnityEngine;

namespace Code.Weapons
{
    public class MiningTool : MonoBehaviour
    {
        public ParticleSystem MineEffect;
        public float MiningRate;
        public float MiningEfficiency;
        public float MineRange;
        public LayerMask MineralMask;

        private TurretMovement turret;
        private bool isCycling;

        void Start()
        {
            turret = GetComponentInParent<TurretMovement>();
        }

        public void Mine()
        {
            if (!isCycling && turret.enabled)
            {
                MineEffect.Play();
                ExtractMinerals();
                StartCoroutine(CycleAmmo());
            }
        }

        IEnumerator CycleAmmo()
        {
            isCycling = true;
            yield return new WaitForSeconds(MiningRate);
            isCycling = false;
        }

        void ExtractMinerals()
        {
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, MineRange, MineralMask))
            {
                hit.collider.GetComponent<MineralDeposit>().Mine(MiningEfficiency);
            }
        }
    }
}
