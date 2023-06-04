using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class WeighHeart : MonoBehaviour
    {
        //Weighing Variables
        private bool ritualStarted;
        private int RadNum;

        //Fade Variables
        public float fadeDuration = 2;
        public Color fadeColorAlive;
        public Color fadeColorDead;
        private Renderer rend;

        private void Start()
        {
            rend = GetComponent<Renderer>();
        }

        public void WeighingHeart()
        {
            if (!ritualStarted)
            {
                ritualStarted = true; 
                RadNum = Random.Range(0, 2);
                
                if (RadNum == 0)
                {
                    Debug.Log("You died AGAIN! Bye bye...");
                    FadeOut(fadeColorDead);
                } 
                else if ( RadNum == 1)
                {
                    Debug.Log("You're still part of the live, laugh, love community...");
                    FadeOut(fadeColorAlive);
                } 
                else
                {
                    Debug.Log("Something went horribly wrong!");
                }
            }
        }


        public void FadeIn(Color fadeColor)
        {
            Fade(1, 0, fadeColor);
        }

        public void FadeOut(Color fadeColor)
        {
            Fade(0, 1, fadeColor);
        }

        public void Fade(float alphaIn, float alphaOut, Color fadeColor)
        {
            StartCoroutine(FadeRoutine(alphaIn, alphaOut, fadeColor));
        }

        public IEnumerator FadeRoutine(float alphaIn, float alphaOut, Color fadeColor)
        {
            float timer = 0; 
            while(timer <= fadeDuration)
            {
                Color newColor = fadeColor;
                newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);

                rend.material.SetColor("_Color", newColor);

                timer += Time.deltaTime;
                yield return null; 
            }

            Color newColor2 = fadeColor;
            newColor2.a = alphaOut;

            rend.material.SetColor("_Color", newColor2);
        }

    }
}
