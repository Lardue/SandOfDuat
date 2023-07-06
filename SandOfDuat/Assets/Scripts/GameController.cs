using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class GameController : MonoBehaviour
    {
        public HeartBehaviour heartVR;
        public HeartBehaviour heartDesktop;
        public WeighHeart faderVR;
        public WeighHeart faderDesktop;

        private GameObject player;
        private bool vrActive;  

        public void  SetPlayer (GameObject pPlayer, bool pVRActive)
        {
            player = pPlayer;
            vrActive = pVRActive;
        }

        public void StartCeremony ()
        {
            if (vrActive)
            {
                heartVR.makeScaleParent();
                faderVR.WeighingHeart(); 
            }
            else
            {
                heartDesktop.makeScaleParent();
                faderDesktop.WeighingHeart(); 
            }
        }


    }
}
