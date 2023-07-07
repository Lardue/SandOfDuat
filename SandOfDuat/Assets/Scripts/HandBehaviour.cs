using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SandOfDuat
{
    public class HandBehaviour : MonoBehaviour
    {
        private Animator handAnimator;

        private void Start()
        {
            handAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                handAnimator.Play("Grab_Heart");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Debug.Log("Heloooooo");
            }
        }
    }
}
