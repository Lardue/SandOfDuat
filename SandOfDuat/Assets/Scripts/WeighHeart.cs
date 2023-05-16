using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class WeighHeart : MonoBehaviour
    {
        private bool ritualStarted;
        public int RadNum;

        public void weighingHeart()
        {
            if (!ritualStarted)
            {
                ritualStarted = true; 
                RadNum = Random.Range(0, 2);
                
                if (RadNum == 0)
                {
                    Debug.Log("You died AGAIN! Bye bye...");
                } 
                else if ( RadNum == 1)
                {
                    Debug.Log("You're still part of the live, laugh, love community...");
                } else
                {
                    Debug.Log("Something went horribly wrong!");
                }
            }
        }
    }
}
