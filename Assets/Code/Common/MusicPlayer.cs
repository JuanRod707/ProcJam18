using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Common
{
    public class MusicPlayer : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
