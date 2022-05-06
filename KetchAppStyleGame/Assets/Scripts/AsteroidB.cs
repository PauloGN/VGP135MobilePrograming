using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidB : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        
        PlayerHealth playerHeathScript = other.GetComponent<PlayerHealth>();

        if (playerHeathScript == null)
        {
            return;
        }

        playerHeathScript.crash(); 

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }


}
