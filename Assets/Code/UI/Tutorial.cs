using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class Tutorial : MonoBehaviour
    {
        public Text TextArea;
        public float SecondsPerChar;

        private AudioSource audio;
        private int msgIndex;

        private string[] tutoMessages =
        {
            "Hello surveyor. I understand this is your first day at the corporation. Do not worry, just follow my lead and you will be productive.",
            "First of all, get acquainted with your survey craft, use WASD to move around. On the top left of your HUD you can see the status of your hull integrity.",
            "All survey crafts come equipped with two double plasma cannons, these cannons deal a great amount of damage but require stored energy to fire.",
            "Use your mouse to aim the cannons and left click to fire them, keep an eye on the stored energy gauge on your crosshair.",
            "Your assignment today is to provide full topographic data of the cave, you must explore the cave in its entirety.",
            "The progress of your exploration can be seen in the top right corner of your HUD, right inside the mini map area, which you can expand by pressing TAB",
            "You may have noticed some glowing minerals around the cave, you can extract these by pressing E and going into mining mode, the mining tool works just like your cannons do.",
            "Be on your guard for Shrieks, they are the dominant local wildlife, very aggressive and territorial.",
            "Lately we have discovered that Shrieks have a genetic reaction to the prescence of minerals, meaning that they will have different characteristics according to the cave they inhabit.",
            "Once your mission is complete, leave the cave, we'll regroup at home base. For your own safety do not linger in these caves."
        };

        void Start()
        {
            msgIndex = 0;
            audio = GetComponent<AudioSource>();
            StartCoroutine(DisplayAndWait());
        }
        
        IEnumerator DisplayAndWait()
        {
            TextArea.text = tutoMessages[msgIndex];
            var waitTime = tutoMessages[msgIndex].Length * SecondsPerChar;
            audio.Play();
            yield return new WaitForSeconds(waitTime);
            CycleMessage();
        }

        void CycleMessage()
        {
            msgIndex++;
            if (msgIndex < tutoMessages.Length)
            {
                StartCoroutine(DisplayAndWait());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
