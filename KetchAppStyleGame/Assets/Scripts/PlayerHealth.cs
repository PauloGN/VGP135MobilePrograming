using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ScoreTrack scoreTrackREF;
    [SerializeField] private int bonus;
    [SerializeField] private GameOverPanel gameOverPanel = null;
    public void crash()
    {
        gameObject.SetActive(false);
        gameOverPanel.OnGameOver();
    }

    public void SetScore()
    {
        scoreTrackREF.SetScore(bonus);
    }

}
