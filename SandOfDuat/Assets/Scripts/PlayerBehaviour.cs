using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public GameObject teleportationTarget;
        public GameObject player;

        public GameObject heart;

        public void goTroughPortal()
        {
            player.transform.position = teleportationTarget.transform.position;
        }
        public void ActivateHeart()
        {
            heart.SetActive(true);
        }
    }
}
