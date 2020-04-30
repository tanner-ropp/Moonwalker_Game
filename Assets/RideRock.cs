using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideRock : MonoBehaviour
{
    public GameObject rocky;
    //public GameObject player;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject == rocky)
        {
            //This will make the player a child of the Obstacle
            gameObject.transform.parent = col.gameObject.transform; //Change "myPlayer" to your player
        }
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.transform.parent = null;
    }
}
