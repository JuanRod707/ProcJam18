using Code.Movement;
using Code.Weapons;
using UnityEngine;

namespace Code.PlayerInput
{
    public class MouseInput : MonoBehaviour
    {
        public PlasmaCannon Cannons;
        public MiningTool MiningTool;

        void Update ()
        {
            if (Input.GetMouseButton(0))
            {
                Cannons.Fire();
                MiningTool.Mine();
            }
        }
    }
}
