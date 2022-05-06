using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private float scoremultiplyer = 0.0f;

    [SerializeField] GameObject playerREF;
    [SerializeField] Spawner spawnerREF;
    [SerializeField] private float getHarderTimer = 30.0f;

    //variables to control the increse of the score and difficulty of the game

    private float score;
    private float getHarderDelay = 0.0f;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * scoremultiplyer;
        updateScoreText();

        getHarderDelay += Time.deltaTime;
        if (getHarderDelay >= getHarderTimer)
        {
            spawnerREF.GettingHarder();
            getHarderDelay = 0.0f;
        }

    }

    void updateScoreText()
    {
        scoreTxt.text = Mathf.FloorToInt(score).ToString();
    }

    public void SetScore(int bonus)
    {
        score += bonus;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

}
