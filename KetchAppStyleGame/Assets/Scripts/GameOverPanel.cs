using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoresTxt;
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private GameObject resetPanel = null;
    [SerializeField] private GameObject scoreSysREF = null;
    [SerializeField] private GameObject spawner = null;

    static private int[] scores = { 0, 0, 0, 0, 0 };
    private int currentScore = 0;

    private void Start()
    {
        LoadSaveGame();
    }

    private void LoadSaveGame()
    {
        if (SaveGameData.Instance.LoadGameScore()._scores != null)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = SaveGameData.Instance.LoadGameScore()._scores[i];
            }
        }
    }

    public void OnGameOver()
    {
        UpdateHighestScore();
        scoreSysREF.SetActive(false);
        spawner.SetActive(false);
        gameOverPanel.SetActive(true);

        SaveGameData.Instance.SaveToFile(scores);
    }
    public void RestartGame()
    {
        AdsManager.instance.ShowBunnerfor_x_Seconds();
        SceneManager.LoadScene(1);
    }
    public void OpenMainMenu()
    {
        AdsManager.instance.ShowInterstitialAd();
        AdsManager.instance.ShowBanner();
        SceneManager.LoadScene(0);
    }

    public void UpdateHighestScore()
    {
        currentScore = scoreSysREF.GetComponent<ScoreTrack>().GetScore();
        currentScoreText.text = $"Game Over current score: {currentScore}";
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] <= currentScore)
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

        gameOverPanel.SetActive(false);
        resetPanel.SetActive(true);

    }

    public void OnNoResetScores()
    {
        gameOverPanel.SetActive(true);
        resetPanel.SetActive(false);
    }


    public void OnYesResetScores()
    {
        AdsManager.instance.ShowInterstitialAd();
        for (int i = 0; i < scores.Length; i++)
        {

            scores[i] = 0;

        }

        for (int i = 0; i < scoresTxt.Length; i++)
        {

            scoresTxt[i].text = $"Position {i + 1}: " + scores[i].ToString();

        }

        SaveGameData.Instance.SaveToFile(scores);

        gameOverPanel.SetActive(true);
        resetPanel.SetActive(false);

    }

}


