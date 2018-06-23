using System.Linq;
using UnityEngine;

namespace Code.UI.ControlRoom
{
    public class MissionBar : MonoBehaviour
    {
        public Transform ListContent;
        public GameObject CaveMissionItemPf;
        public int MissionCount;

        void Start()
        {
            FillMissionBar();
        }

        void FillMissionBar()
        {
            foreach (var i in Enumerable.Range(0, MissionCount))
            {
                Instantiate(CaveMissionItemPf, ListContent);
            }
        }
    }
}
