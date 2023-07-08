using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class ScaleState : MonoBehaviour
    {
        public DetectVR detecterScript;

        private int random; 

        public WeighHeart faderVR;
        public WeighHeart faderDesktop;

        public void SetRandom(int pRandom)
        {
            random = pRandom;
        }

        public void updateStatetoFinished()
        {
            if (detecterScript.playingInVR)
            {
                faderVR.StartEnd(random);
            } 
            else
            {
                faderDesktop.StartEnd(random);
            }

        }

    }
}
