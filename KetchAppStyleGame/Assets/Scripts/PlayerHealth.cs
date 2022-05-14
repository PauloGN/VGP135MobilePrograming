using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    normal,
    powerUp
}



public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ScoreTrack scoreTrackREF;
    [SerializeField] private int bonus;
    [SerializeField] private GameOverPanel gameOverPanel = null;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject indicator;
    [SerializeField] private int powerUpTimer = 5;

    [HideInInspector]public PlayerState _playerState;

    private int countPwUp = 0;

    

    private void Start()
    {
        _playerState = PlayerState.normal;
    }

    public void crash()
    {
        gameObject.SetActive(false);
        gameOverPanel.OnGameOver();
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void SetScore()
    {
        scoreTrackREF.SetScore(bonus);
    }


    public void SetPlayerstate(PlayerState playerState)
    {
        _playerState = playerState;
        SetIndicator();
    }

    private void SetIndicator()
    {
        switch (_playerState)
        {
            case PlayerState.normal:

                indicator.SetActive(false);

                break;
            case PlayerState.powerUp:

                countPwUp++;
                indicator.SetActive(true);
                StartCoroutine(PowerupCountDown());

                break;
            default:
                break;
        }
    }


    IEnumerator PowerupCountDown()
    {
        
        yield return new WaitForSeconds(powerUpTimer);//starts a counter internally in this case 5 seconds after the time it will execute the next line of code
        countPwUp--;
        if(countPwUp <= 0)
        {
            SetPlayerstate(PlayerState.normal);
            countPwUp = 0;
        }

    }


}
