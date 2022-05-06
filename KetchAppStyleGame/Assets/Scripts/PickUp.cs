using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHeathScript = other.GetComponent<PlayerHealth>();

        if (playerHeathScript == null)
        {
            return;
        }

        playerHeathScript.SetScore();
        //Debug.Log("Pick Up Collected");

        Destroy(gameObject);
    }

}
