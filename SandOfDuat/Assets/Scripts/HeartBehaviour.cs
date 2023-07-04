using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace SandOfDuat
{
    public class HeartBehaviour : MonoBehaviour
    {
        public GameObject scalePan;

        private bool isGrabbed; 

        public void makeScaleParent()
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            transform.SetParent(scalePan.transform);
        }

        public void heartIsGrabbed ()
        {
            if (!isGrabbed)
            {
                isGrabbed = true;
                transform.SetParent(null);
                this.GetComponent<Rigidbody>().useGravity = false;
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }
}
