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

        public AudioSource coinFlip; 

        private GameObject player;
        private bool vrActive;
        private bool coinCollected;

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

                if(coinCollected)
                {
                    coinFlip.Play();
                }

                faderVR.WeighingHeart(coinCollected); 
            }
            else
            {
                heartDesktop.makeScaleParent();

                if (coinCollected)
                {
                    coinFlip.Play();
                }

                faderDesktop.WeighingHeart(coinCollected); 
            }
        }

        public void CollectCoin ()
        {
            coinCollected = true;
            Debug.Log("Coin Collected, Biatch.");
        }


    }
}
