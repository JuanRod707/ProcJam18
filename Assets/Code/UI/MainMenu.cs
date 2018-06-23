using Code.Common;
using UnityEngine;

namespace Code.UI
{
    [RequireComponent(typeof(SceneTransition))]
    public class MainMenu : MonoBehaviour
    {
        public void OnNewGame()
        {
            GetComponent<SceneTransition>().DelayedSceneChange("ControlRoom");
        }

        public void OnContinueGame()
        {
            GetComponent<SceneTransition>().DelayedSceneChange("ControlRoom");
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
