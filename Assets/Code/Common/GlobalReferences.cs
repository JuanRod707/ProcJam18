using Assets.Code.UI;
using UnityEngine;

namespace Code.Common
{
    public static class GlobalReferences
    {
        public static FadeScreen FadeScreen { get { return GameObject.Find("FadeScreen").GetComponent<FadeScreen>(); } }
    }
}
