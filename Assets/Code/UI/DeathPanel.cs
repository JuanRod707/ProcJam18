using Code.Common;
using Code.Session;
using UnityEngine;

namespace Code.UI
{
    [RequireComponent(typeof(SceneTransition))]
    public class DeathPanel : MonoBehaviour
    {
        public DynamicLabel DeathReport;
        public CanvasGroup CanvasGroup;
        public float FadeSpeed;

        private bool fadeIn;

        public void ShowDeathPanel()
        {
            gameObject.SetActive(true);
            fadeIn = true;
            FillDeathReport();
        }

        void Update()
        {
            if (fadeIn)
            {
                CanvasGroup.alpha += FadeSpeed;
            }
        }

        void FillDeathReport()
        {
            var player = LiveSession.PlayerData;
            DeathReport.SetLabel(player.Name, LiveSession.CaveData.Name, player.ServiceDays.ToString(), player.Balance.ToString());
        }

        public void EndScene()
        {
            GetComponent<SceneTransition>().DelayedSceneChange("MainMenu");
        }
    }
}
