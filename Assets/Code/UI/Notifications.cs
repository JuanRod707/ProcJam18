using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class Notifications : MonoBehaviour
    {
        public Text NotificationText;

        public void DisplayMissionAccomplished()
        {
            NotificationText.text = "Mission accomplished";
        }
    }
}
