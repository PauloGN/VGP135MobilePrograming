using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    private PlayerHealth playerHeathScript = null;
    private void OnTriggerEnter(Collider other)
    {
        playerHeathScript = other.GetComponent<PlayerHealth>();

        if (playerHeathScript == null)
        {
            return;
        }

       
        //Debug.Log("Pick Up Collected");
        if (gameObject.CompareTag("PowerUp"))
        {
            playerHeathScript.SetPlayerstate(PlayerState.powerUp);
            
        }
        else
        {
            playerHeathScript.SetScore();
        }
        

        Destroy(gameObject);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }


}
