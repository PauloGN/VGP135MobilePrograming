using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidB : MonoBehaviour
{

    [SerializeField] private GameObject[] explosion;
       

    private void OnTriggerEnter(Collider other)
    {

        
        PlayerHealth playerHeathScript = other.GetComponent<PlayerHealth>();

        if (playerHeathScript == null)
        {
            return;
        }

      // playerHeathScript.SetPlayerstate(PlayerState.powerUp);

        switch (playerHeathScript._playerState)
        {
            case PlayerState.normal:

                playerHeathScript.crash();

                break;
            case PlayerState.powerUp:

                GetRamdomExplosion();
                Destroy(gameObject);

                break;
            default:
                break;
        }



    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }


   private void GetRamdomExplosion()
    {
        GameObject instance = explosion[Random.Range(0, explosion.Length)];
        Instantiate(instance, transform.position, transform.rotation);
    }


}
