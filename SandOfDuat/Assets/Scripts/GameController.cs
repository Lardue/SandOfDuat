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

        public AudioSource heartbeatVR;
        public AudioSource heartbeatDesktop;

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
                StartCoroutine(FadeOut(heartbeatVR, 3f));

                if(coinCollected)
                {
                    coinFlip.Play();
                }

                faderVR.WeighingHeart(coinCollected); 
            }
            else
            {
                heartDesktop.makeScaleParent();
                StartCoroutine(FadeOut(heartbeatDesktop, 3f));

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

        public void StartHeart ()
        {
            if (vrActive)
            {
                StartCoroutine(FadeIn(heartbeatVR, 1f));
            }
            else
            {
                StartCoroutine(FadeIn(heartbeatDesktop, 3f));
            }
        }

        public IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
        {

            while (audioSource.volume < 0.5f)
            {
                audioSource.volume += .5f * Time.deltaTime / FadeTime;

                yield return null;
            }

            Debug.Log("Done");
        }

        public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }
    }
}
