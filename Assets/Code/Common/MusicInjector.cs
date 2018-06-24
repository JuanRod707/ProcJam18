using UnityEngine;

namespace Code.Common
{
    public class MusicInjector : MonoBehaviour
    {
        public AudioClip Track;

        void Start()
        {
            var musicPlayer = GlobalReferences.MusicPlayer;
            if (musicPlayer != null)
            {
                var player = musicPlayer.GetComponent<AudioSource>();

                if (player.clip != Track)
                {
                    player.clip = Track;
                    player.Play();
                }
            }
        }
    }
}
