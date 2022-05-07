using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ScoreTrack scoreTrackREF;
    [SerializeField] private int bonus;
    [SerializeField] private GameOverPanel gameOverPanel = null;
    [SerializeField] private GameObject explosion;
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

}
