using UnityEngine;

namespace Code.Weapons
{
    public class MiningToolAnimator : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Activate()
        {
            animator.SetBool("IsActive", true);
        }

        public void Deactivate()
        {
            if (animator != null)
            {
                animator.SetBool("IsActive", false);
            }
        }
    }
}
