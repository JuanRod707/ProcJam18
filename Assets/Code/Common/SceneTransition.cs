using System.Collections;
using Code.Session;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Common
{
    public class SceneTransition : MonoBehaviour
    {
        public void DelayedSceneChange(string scene)
        {
            GlobalReferences.FadeScreen.FadeOut();
            StartCoroutine(WaitAndChangeScene(scene));
        }

        IEnumerator WaitAndChangeScene(string scene)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(scene);
        }
    }
}
