using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RtanRain
{
    public class Rtan : MonoBehaviour
    {
        float direction = 0.05f;

        SpriteRenderer sprite;

        private void Start()
        {
            Application.targetFrameRate = 60;
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                sprite.flipX = !sprite.flipX;
                direction = -direction;
            }

            if (transform.position.x > 2.6f)
            {
                sprite.flipX = true;
                direction = -0.05f;
            }
            else if (transform.position.x < -2.6f)
            {
                sprite.flipX = false;
                direction = 0.05f;
            }

            transform.position += Vector3.right * direction;
        }
    }
}