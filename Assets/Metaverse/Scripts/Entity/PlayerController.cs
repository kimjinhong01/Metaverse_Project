using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class PlayerController : BaseController
    {
        private Camera camera;
        private UIManager uiManager;
        public bool isStop;

        protected override void Start()
        {
            base.Start();
            camera = Camera.main;
            uiManager = FindObjectOfType<UIManager>();
            isStop = false;
        }

        protected override void HandleAction()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertial = Input.GetAxisRaw("Vertical");
            if (!isStop)
                movementDirection = new Vector2(horizontal, vertial).normalized;
            else
                movementDirection = Vector2.zero;

            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            if (lookDirection.magnitude < .9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            isStop = true;
            if (collision.CompareTag("FlappPlane"))
            {
                uiManager.ChangeState(UIState.FlappyPlane);
            }
            else if (collision.CompareTag("TheStack"))
            {
                uiManager.ChangeState(UIState.TheStack);
            }
            else if (collision.CompareTag("TopDown"))
            {
                uiManager.ChangeState(UIState.TopDown);
            }
            else if (collision.CompareTag("MyShield"))
            {
                uiManager.ChangeState(UIState.MyShield);
            }
            else if (collision.CompareTag("RtanRain"))
            {
                uiManager.ChangeState(UIState.RtanRain);
            }
            else if (collision.CompareTag("FindRtan"))
            {
                uiManager.ChangeState(UIState.FindRtan);
            }
        }
    }
}