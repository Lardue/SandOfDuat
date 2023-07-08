using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class ScaleState : MonoBehaviour
    {
        public bool animationFinished = false;
        public DetectVR detecterScript;

        public WeighHeart faderVR;
        public WeighHeart faderDesktop;

        public void updateStatetoFinished()
        {
            animationFinished = true;

            if (detecterScript.playingInVR)
            {
                faderVR.StartEnd();
            } 
            else
            {
                faderDesktop.StartEnd();
            }

        }

    }
}
