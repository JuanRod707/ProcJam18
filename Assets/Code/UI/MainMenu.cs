using Code.Common;
using Code.Helpers;
using Code.IO.DataSchemas;
using Code.Session;
using UnityEngine;

namespace Code.UI
{
    [RequireComponent(typeof(SceneTransition))]
    public class MainMenu : MonoBehaviour
    {
        public void OnNewGame()
        {
            LiveSession.SetPlayerData(new PlayerData());
            GetComponent<SceneTransition>().DelayedSceneChange("ControlRoom");
        }

        public void OnContinueGame()
        {
            if (CharacterSave.IsSavePresent())
            {
                LiveSession.SetPlayerData(CharacterSave.Load());
                GetComponent<SceneTransition>().DelayedSceneChange("ControlRoom");
            }
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
