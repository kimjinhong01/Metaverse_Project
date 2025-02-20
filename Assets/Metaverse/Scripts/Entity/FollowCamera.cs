using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        Transform target;
        [SerializeField]
        Vector3 offsetVec;

        [SerializeField]
        Vector2 center;
        [SerializeField]
        Vector2 mapSize;

        [SerializeField]
        float cameraMoveSpeed;
        float height;
        float width;

        void Start()
        {
            if (target == null)
                return;

            height = Camera.main.orthographicSize;
            width = height * Screen.width / Screen.height;
        }

        void Update()
        {
            if (target == null)
                return;

            LimitCameraArea();
        }

        void LimitCameraArea()
        {
            transform.position = Vector3.Lerp(
                transform.position,
                target.position + offsetVec,
                Time.deltaTime * cameraMoveSpeed);

            float lx = mapSize.x - width;
            float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

            float ly = mapSize.y - height;
            float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

            transform.position = new Vector3(clampX, clampY, offsetVec.z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(center, mapSize * 2);
        }
    }
}