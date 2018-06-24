using Code.Common;
using Code.ControlRoom;
using Code.Helpers;
using Code.Helpers.Generators;
using Code.IO.DataSchemas;
using Code.Level;
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
            LiveSession.SetCaveData(NameGenerator.GenerateCaveName(), 3, new [] { Mineral.White });
            LiveSession.SetCurrentMission(new MapMission(3));

            GetComponent<SceneTransition>().DelayedSceneChange("CaveTutorial");
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
