using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SandOfDuat
{
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent triggerEnterEvent;
        public UnityEvent triggerStayEvent;
        public UnityEvent triggerExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                triggerEnterEvent?.Invoke();
            }

            if (other.gameObject.CompareTag("Heart"))
            {
                triggerEnterEvent?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown("e"))
            {
                triggerStayEvent?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                triggerExitEvent?.Invoke();
            }
        }
    }
}
