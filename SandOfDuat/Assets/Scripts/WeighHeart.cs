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

        //Sound Variables 
        public AudioSource soundDeath;
        public AudioSource soundAfterlife;

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

        private void FixedUpdate()
        {
            if (ritualStarted && !ritualEnded)
            {
                if (scaleScript.animationFinished)
                {
                    ritualEnded = true;
                    StartCoroutine(EndGame());
                }
            }
        }
       
        private IEnumerator EndGame()
        {
            yield return new WaitForSeconds(3f);

            if (RadNum == 0)
            {
                FadeOut(fadeColorDead);
                StartCoroutine(PlayEndSound(5));
            }

            if (RadNum == 1)
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

            if (RadNum == 0)
            {
                soundDeath.Play();
                StartCoroutine(ResetGame(40));
            }

            if (RadNum == 1)
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
