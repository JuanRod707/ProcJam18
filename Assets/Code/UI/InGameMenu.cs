using Code.Common;
using UnityEngine;

namespace Code.UI
{
    [RequireComponent(typeof(SceneTransition))]
    public class InGameMenu : MonoBehaviour
    {
        public void BackToMenu()
        {
            GetComponent<SceneTransition>().DelayedSceneChange("MainMenu");
        }
    }
}
