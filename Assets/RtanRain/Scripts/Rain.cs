using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RtanRain
{
    public class Rain : MonoBehaviour
    {
        float size = 1.0f;
        int score = 1;

        SpriteRenderer sprite;

        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();

            float x = Random.Range(-2.4f, 2.4f);
            float y = Random.Range(3.0f, 5.0f);

            transform.position = new Vector3(x, y, 0);

            int type = Random.Range(1, 5);

            switch (type)
            {
                case 1:
                    size = 0.8f;
                    score = 1;
                    sprite.color = new Color(61 / 255f, 85 / 255f, 188 / 255f, 1f);
                    break;
                case 2:
                    size = 1.0f;
                    score = 2;
                    sprite.color = new Color(119 / 255f, 140 / 255f, 231 / 255f, 1f);
                    break;
                case 3:
                    size = 1.2f;
                    score = 3;
                    sprite.color = new Color(59 / 255f, 77 / 255f, 156 / 255f, 1f);
                    break;
                case 4:
                    size = 0.8f;
                    score = -5;
                    sprite.color = new Color(255 / 255f, 100 / 255f, 255 / 255f, 1f);
                    break;
            }

            transform.localScale = new Vector3(size, size, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Player"))
            {
                GameManager.Instance.AddScore(score);

                Destroy(gameObject);
            }
        }
    }
}