using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FindRtan
{
    public class RetryButton : MonoBehaviour
    {
        public void Main()
        {
            SceneManager.LoadScene("GameScene6_1");
        }

        public void Retry()
        {
            SceneManager.LoadScene("GameScene6_2");
        }

        public void Exit()
        {
            AudioManager.Instance.DestroyMusic();
            SceneManager.LoadScene(0);
        }
    }
}