using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FindRtan
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public Card firstCard;
        public Card secondCard;

        public Text timeTxt;
        public GameObject endTxt;

        AudioSource audioSource;
        public AudioClip clip;

        public int cardCount = 0;
        float time = 0f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");

            if (time > 30)
            {
                GameOver();
            }
        }

        public void Matched()
        {
            if (firstCard.idx == secondCard.idx)
            {
                // ÆÄ±«ÇØ¶ó.
                audioSource.PlayOneShot(clip);
                firstCard.DestroyCard();
                secondCard.DestroyCard();
                cardCount -= 2;
                if (cardCount == 0)
                {
                    Time.timeScale = 0;
                    endTxt.SetActive(true);
                }
            }
            else
            {
                // ´Ý¾Æ¶ó.
                firstCard.CloseCard();
                secondCard.CloseCard();
            }

            firstCard = null;
            secondCard = null;
        }

        void GameOver()
        {
            Time.timeScale = 0;
            endTxt.SetActive(true);
        }
    }
}