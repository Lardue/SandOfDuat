using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class PortalCamera : MonoBehaviour
    {
        [SerializeField] DetectVR detecter;

        public Transform vrCam;
        public Transform desktopCam;
        public Transform portalDesert;
        public Transform portalHFK;

        private Transform playerCam;
        private Transform portalCam;

        private void Start()
        {
            portalCam = gameObject.GetComponent<Transform>();

            if (detecter.playingInVR)
            {
                playerCam = vrCam;
            } 
            else
            {
                playerCam = desktopCam;
            }

            portalCam.position = new Vector3(portalCam.position.x, playerCam.position.y, portalCam.position.z);
        }

        private void Update()
        {
            Matrix4x4 m = portalDesert.localToWorldMatrix * portalHFK.worldToLocalMatrix * playerCam.localToWorldMatrix;
            
            Vector4 newPos = m.GetColumn(3);
            //newPos.Set(0, newPos.y, newPos.z, newPos.z);

            Quaternion newRot = m.rotation;
            newRot.Set(0, newRot.y, newRot.z, newRot.w);

            portalCam.SetPositionAndRotation(newPos, newRot);
        }
    }
}
