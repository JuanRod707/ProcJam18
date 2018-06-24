using Code.Helpers;
using UnityEngine;

namespace Code.Shrieks
{
    public class ShriekBrainMenu : MonoBehaviour
    {
        public bool MoveLeft;
        public AudioClip[] AwakeSfx;
        private ShriekMovement movement;

        void Start()
        {
            movement = GetComponent<ShriekMovement>();
            PlayAwakeSound();
        }

        void Update()
        {
            if (MoveLeft)
            {
                movement.TurnLeft();
            }
            else
            {
                movement.TurnRight();
            }

            movement.MoveForward();
        }
        
        void PlayAwakeSound()
        {
            var audioPlayer = GetComponent<AudioSource>();

            if (MathHelper.ChanceD100(40))
            {
                audioPlayer.clip = AwakeSfx.PickOne();
                audioPlayer.Play();
            }
        }
    }
}
