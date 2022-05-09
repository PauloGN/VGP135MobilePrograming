using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        if (SaveGameData.Instance.LoadGameScore()._scores.Length >= 1)
        {
            scoreTxt.text = "Leader Score: " + SaveGameData.Instance.LoadGameScore()._scores[0].ToString();
        }
    }

}
