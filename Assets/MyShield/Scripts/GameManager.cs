using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyShield
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public GameObject square;
        public GameObject endPanel;
        public Text timeText;
        public Text nowScore;
        public Text bestScore;

        public Animator anim;

        bool isPlay = true;

        float time = 0.0f;

        string key = "bestScore";

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1.0f;
            InvokeRepeating("MakeSquare", 0f, 1f);
        }

        // Update is called once per frame
        void Update()
        {
            if (isPlay)
            {
                time += Time.deltaTime;
                timeText.text = time.ToString("N2");
            }
        }

        void MakeSquare()
        {
            Instantiate(square);
        }

        public void GameOver()
        {
            isPlay = false;
            anim.SetTrigger("onDie");
            Invoke("TimeStop", 0.5f);
            nowScore.text = time.ToString("N2");

            // �ְ������� �ִٸ�
            if (PlayerPrefs.HasKey(key))
            {
                float best = PlayerPrefs.GetFloat(key);
                // �ְ����� < ���� ����
                if (best < time)
                {
                    // ���� ������ �ְ� ������ �����Ѵ�.
                    PlayerPrefs.SetFloat(key, time);
                    bestScore.text = time.ToString("N2");
                }
                else
                {
                    bestScore.text = best.ToString("N2");
                }
            }
            // �ְ������� ���ٸ�
            else
            {
                // ���� ������ �����Ѵ�.
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }

            endPanel.SetActive(true);
        }

        void TimeStop()
        {
            Time.timeScale = 0.0f;
        }
    }
}