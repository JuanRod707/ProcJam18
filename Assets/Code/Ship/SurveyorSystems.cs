using Code.Movement;
using Code.Weapons;
using UnityEngine;

namespace Code.Ship
{
    public class SurveyorSystems : MonoBehaviour
    {
        public TurretMovement Cannons;
        public TurretMovement Miner;
        public MiningTool MiningTool;
        public MiningToolAnimator MiningToolAnimator;

        private SurveyorMode currentMode;

        void Start()
        {
            SetMode();
        }

        public void SwitchMode()
        {
            currentMode = currentMode == SurveyorMode.Attack ? SurveyorMode.Mining : SurveyorMode.Attack;
            SetMode();
        }

        void SetMode()
        {
            if (currentMode == SurveyorMode.Attack)
            {
                Cannons.enabled = true;
                Miner.enabled = false;
                MiningToolAnimator.Deactivate();
            }
            else
            {
                Cannons.enabled = false;
                Miner.enabled = true;
                MiningToolAnimator.Activate();
            }
        }
    }
}
