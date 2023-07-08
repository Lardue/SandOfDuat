using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SandOfDuat
{
    public class WeighHeart : MonoBehaviour
    {
        //Weighing Variables
        private bool ritualStarted;
        private bool ritualEnded;
        private int radNum;

        //Scale Variables 
        [SerializeField] ScaleState scaleScript;
        public GameObject scale;
        private Animator scaleAnimator;

        //Fade Variables
        public float fadeDuration = 2;
        public Color fadeColorAlive;
        public Color fadeColorDead;
        private Renderer rend;

        //Sound Variables 
        public AudioSource soundDeath;
        public AudioSource soundAfterlife;

        private void Start()
        {
            rend = GetComponent<Renderer>();
            scaleAnimator = scale.GetComponent<Animator>();
        }


        public void WeighingHeart(bool pCoin)
        {
            if (!ritualStarted)
            {
                ritualStarted = true;

                if (pCoin)
                {
                    Debug.Log("What a sweet day to be rich and priviledged!");
                    radNum = 1;
                    scaleAnimator.Play("Heavy_Left");
                }
                else
                {
                    radNum = Random.Range(0, 2);

                    if (radNum == 0)
                    {
                        Debug.Log("You died AGAIN! Bye bye...");
                        scaleAnimator.Play("Heavy_Right");
                    }
                    else if (radNum == 1)
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
        }

        private void Update()
        {
            if (ritualStarted && !ritualEnded)
            {
                Debug.Log("Level 1");
                if (scaleScript.animationFinished)
                {
                    ritualEnded = true;
                    Debug.Log("End is starting");
                    StartCoroutine(EndGame());
                }
            }
        }

        private IEnumerator EndGame()
        {
            yield return new WaitForSeconds(3f);

            Debug.Log("Things should be happening??????");
            if (radNum == 0)
            {
                FadeOut(fadeColorDead);
                StartCoroutine(PlayEndSound(5));
            }

            if (radNum == 1)
            {
                FadeOut(fadeColorAlive);
                StartCoroutine(PlayEndSound(5));
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
            while (timer <= fadeDuration)
            {
                Color newColor = fadeColor;
                newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

                rend.material.SetColor("_Color", newColor);

                timer += Time.deltaTime;
                yield return null;
            }

            Color newColor2 = fadeColor;
            newColor2.a = alphaOut;

            rend.material.SetColor("_Color", newColor2);
        }

        private IEnumerator PlayEndSound(float pSeconds)
        {
            yield return new WaitForSeconds(pSeconds);

            if (radNum == 0)
            {
                soundDeath.Play();
                StartCoroutine(ResetGame(40));
            }

            if (radNum == 1)
            {
                soundAfterlife.Play();
                StartCoroutine(ResetGame(40));
            }
        }

        private IEnumerator ResetGame(float pSeconds)
        {
            yield return new WaitForSeconds(pSeconds);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

      
    }
}
