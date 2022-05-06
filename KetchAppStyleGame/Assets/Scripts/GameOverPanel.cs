using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoresTxt;
    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private GameObject scoreSysREF = null;
    [SerializeField] private GameObject spawner = null;

    static private int[] scores = { 0, 0, 0, 0, 0}; 
    private int currentScore = 0;

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGameOver()
    {
        UpdateHighestScore();
        scoreSysREF.SetActive(false);
        spawner.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateHighestScore()
    {
        currentScore = scoreSysREF.GetComponent<ScoreTrack>().GetScore();
        for (int i = 0; i < scores.Length; i++)
        {
            if(scores[i] <= currentScore)
            {
                int temp = scores[i];
                scores[i] = currentScore;
                currentScore = temp;

            }

        }

        for (int i = 0; i < scoresTxt.Length; i++)
        {

            scoresTxt[i].text = $"Position {i + 1}: " + scores[i].ToString();

        }


    }
    

    public void ResetScores()
    {

        for (int i = 0; i < scores.Length; i++)
        {

            scores[i] = 0;

        }

        for (int i = 0; i < scoresTxt.Length; i++)
        {

            scoresTxt[i].text = $"Position {i + 1}: " + scores[i].ToString();

        }

    }

}
