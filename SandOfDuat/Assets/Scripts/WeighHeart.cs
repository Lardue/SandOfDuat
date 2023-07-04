using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class WeighHeart : MonoBehaviour
    {
        //Weighing Variables
        private bool ritualStarted;
        private bool ritualEnded;
        private int RadNum;

        //Scale Variables 
        [SerializeField] ScaleState scaleScript; 
        public GameObject scale;
        private Animator scaleAnimator; 

        //Fade Variables
        public float fadeDuration = 2;
        public Color fadeColorAlive;
        public Color fadeColorDead;
        private Renderer rend;

        private void Start()
        {
            rend = GetComponent<Renderer>();
            scaleAnimator = scale.GetComponent<Animator>();
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
                    scaleAnimator.Play("Heavy_Right");
                } 
                else if (RadNum == 1)
                {
                    Debug.Log("You're still part of the live, laugh, love community...");
                    scaleAnimator.Play("Heavy_Left");
                } 
                else
                {
                    Debug.Log("Something went horribly wrong!");
                }
            }
        }

        private void Update()
        {
            if(ritualStarted && !ritualEnded)
            {
                if(scaleScript.animationFinished)
                {
                ritualEnded = true;

                    if (RadNum == 0)
                    {
                        FadeOut(fadeColorDead);
                    } 

                    if (RadNum == 1)
                    {
                        FadeOut(fadeColorAlive);
                    }
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

        private IEnumerator WaitBeforeFade()
        {
            yield return new WaitForSeconds(3);
        }

    }
}
