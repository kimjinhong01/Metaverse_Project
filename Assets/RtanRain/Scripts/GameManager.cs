using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RtanRain
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject rain;

        public Text totalScoreText;
        public Text totalTimeText;

        public GameObject restartButton;
        public GameObject endButton;

        int totalScore;

        float totalTime = 10.0f;

        private void Awake()
        {
            Time.timeScale = 1f;
            Instance = this;
        }

        private void Start()
        {
            InvokeRepeating("MakeRain", 0f, 1f);
        }

        void Update()
        {
            if (totalScore < 0) totalScore = 0;

            if (totalTime > 0)
            {
                totalTimeText.text = "남은시간 " + totalTime.ToString("N2");
            }
            else
            {
                totalTime = 0f;
                Time.timeScale = 0f;
                restartButton.SetActive(true);
                endButton.SetActive(true);
            }

            totalTime -= Time.deltaTime;
        }

        void MakeRain()
        {
            Instantiate(rain);
        }

        public void AddScore(int score)
        {
            totalScore += score;
            totalScoreText.text = "점수 : " + totalScore.ToString();
        }

        public void ReGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void EndGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}