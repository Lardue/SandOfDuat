using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class ScaleState : MonoBehaviour
    {
        public bool animationFinished = false; 

        public void updateStatetoFinished()
        {
            animationFinished = true;
            Debug.Log("Scale macht ihr Ding");
        }
    }
}
