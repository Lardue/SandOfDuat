using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class HeartBehaviour : MonoBehaviour
    {
        public GameObject scalePan;
        private Rigidbody rigidB;

        private void Start()
        {
            rigidB = GetComponent<Rigidbody>(); 
        }

        public void makeScaleParent()
        {
            rigidB.useGravity = false;
            transform.SetParent(scalePan.transform);
        }
    }
}
