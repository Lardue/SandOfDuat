using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
