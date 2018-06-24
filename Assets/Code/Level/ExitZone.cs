using Code.Common;
using Code.Session;
using UnityEngine;

namespace Code.Level
{
    [RequireComponent(typeof(SceneTransition))]
    public class ExitZone : MonoBehaviour
    {
        public string PlayerTag;

        private bool wasTriggered;

        void ExitCave()
        {
            LiveSession.ExitCave();
            GetComponent<SceneTransition>().DelayedSceneChange("ControlRoom");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!wasTriggered)
            {
                if (other.CompareTag(PlayerTag))
                {
                    ExitCave();
                    LiveSession.SavePlayer();
                    wasTriggered = true;
                }
            }
        }
    }
}
