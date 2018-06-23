using Code.Common;
using Code.Session;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.ControlRoom
{
    public class PlayerBar : MonoBehaviour
    {
        public Text CharacterName;
        public DynamicLabel Balance;
        public DynamicLabel ServiceDays;

        void Start()
        {
            CharacterName.text = LiveSession.PlayerData.Name;
            Balance.SetLabel(LiveSession.PlayerData.Balance.ToString());
            ServiceDays.SetLabel(LiveSession.PlayerData.ServiceDays.ToString());
        }

        public void ReturnToMenu()
        {
            LiveSession.SavePlayer();
            GetComponent<SceneTransition>().DelayedSceneChange("MainMenu");
        }
    }
}
