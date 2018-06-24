using System.Text;
using Code.Common;
using Code.ControlRoom;
using Code.Helpers;
using Code.Session;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.ControlRoom
{
    public class CaveMissionItem : MonoBehaviour
    {
        public Text CaveName;
        public DynamicLabel Payment;
        public DynamicLabel CaveSize;
        public DynamicLabel AvailableMaterials;
        public DynamicLabel Mission;

        private CaveMission caveMission;

        private string caveMinerals {
            get
            {
                var sb = new StringBuilder();
                foreach (var m in caveMission.CaveMinerals)
                {
                    sb.Append(string.Format("\n{0}", GameConfiguration.MineralDisplay[m]));
                }

                return sb.ToString();
            }
        }

        void Start()
        {
            caveMission = CaveMission.GenerateCaveMission();
            UpdateView();
        }

        void UpdateView()
        {
            CaveName.text = caveMission.CaveName;
            Payment.SetLabel(caveMission.Mission.Reward.ToString());
            CaveSize.SetLabel(caveMission.CaveSize.ToString());
            AvailableMaterials.SetLabel(caveMinerals);
            Mission.SetLabel("\n" + caveMission.Mission.Description);
        }

        public void LaunchMission()
        {
            LiveSession.SetCaveData(caveMission.CaveName, caveMission.CaveRooms, caveMission.CaveMinerals);
            LiveSession.SetCurrentMission(caveMission.Mission);
            GetComponent<SceneTransition>().DelayedSceneChange("Cave");
        }
    }
}
