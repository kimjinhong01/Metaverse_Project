using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyPlane
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI restartText;
        public Button restartButton;
        public Button exitButton;

        public void Start()
        {
            if (restartText == null)
            {
                Debug.LogError("restart text is null");
            }

            if (scoreText == null)
            {
                Debug.LogError("scoreText is null");
                return;
            }

            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            restartText.gameObject.SetActive(false);

            restartButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        public void OnClickStartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public void OnClickExitButton()
        {
            SceneManager.LoadScene(0);
        }

        public void SetRestart()
        {
            restartButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}