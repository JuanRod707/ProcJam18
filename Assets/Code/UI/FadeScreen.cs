using UnityEditor.Experimental.UIElements;
using UnityEngine;

namespace Assets.Code.UI
{
    public class FadeScreen : MonoBehaviour
    {
        public float FadeSpeed;

        private CanvasGroup canvas;
        private bool fadeOut;

        void Start()
        {
            canvas = GetComponent<CanvasGroup>();
        }

        void Update()
        {
            var deltaFade = fadeOut ? FadeSpeed : -FadeSpeed;
            Fade(deltaFade);
        }

        void Fade(float delta)
        {
            canvas.alpha += delta;
        }

        public void FadeIn()
        {
            fadeOut = false;
        }

        public void FadeOut()
        {
            fadeOut = true;
        }
    }
}
