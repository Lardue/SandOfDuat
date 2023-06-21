using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class PortalCamera : MonoBehaviour
    {
        public Transform playerCam;
        public Transform portalDesert;
        public Transform portalHFK;

        private Transform portalCam;

        private void Start()
        {
            portalCam = gameObject.GetComponent<Transform>();
        }

        private void Update()
        {
            Matrix4x4 m = portalDesert.localToWorldMatrix * portalHFK.worldToLocalMatrix * playerCam.localToWorldMatrix;
            Quaternion q = m.rotation;
            q.Set(0, q.y, q.z, q.w);
            portalCam.SetPositionAndRotation(m.GetColumn(3), q);
        }
    }
}
