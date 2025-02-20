using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform target;
        Vector3 offsetVec;

        void Start()
        {
            if (target == null)
                return;

            offsetVec = new Vector3(0, 0, -10);
        }

        void Update()
        {
            if (target == null)
                return;

            Vector3 pos = transform.position;
            pos = target.position + offsetVec;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);
        }
    }
}