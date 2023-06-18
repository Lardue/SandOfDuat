using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandOfDuat
{
    public class TeleportPlayer : MonoBehaviour
    {

        public GameObject teleportationTarget;
        public GameObject player;

        public void goTroughPortal()
        {
            player.transform.position = teleportationTarget.transform.position;
        }
    }
}
