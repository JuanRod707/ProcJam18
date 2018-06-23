using Assets.Code.UI;
using Code.Level;
using Code.Ship;
using Code.UI;
using UnityEngine;

namespace Code.Common
{
    public static class GlobalReferences
    {
        public static FadeScreen FadeScreen { get { return GameObject.Find("FadeScreen").GetComponent<FadeScreen>(); } }

        public static Cave Cave { get { return GameObject.Find("Cave").GetComponent<Cave>(); } }

        public static CargoBay CargoBay { get { return GameObject.Find("CargoBay").GetComponent<CargoBay>(); } }

        public static Notifications Notifications { get { return GameObject.Find("Notifications").GetComponent<Notifications>(); } }
    }
}
