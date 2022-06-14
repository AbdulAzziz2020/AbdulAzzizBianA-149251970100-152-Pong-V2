using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScene : MonoBehaviour
{
    [Header("For Main Menu")]
    [SerializeField]
    private TMP_InputField setMaxScore;
    [SerializeField]
    private TMP_Text placeHolder;

    #region Scene Manager
    public void Play()
    {
        if(string.IsNullOrEmpty(setMaxScore.text))
        {
            placeHolder.text = "Please fill max score!";
        }
        else
        {
            SceneManager.LoadScene("Game");

            ScoreManager.scorePlayer1 = 0;
            ScoreManager.scorePlayer2 = 0;

            int maxScore = int.Parse(setMaxScore.text);
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

        ScoreManager.scorePlayer1 = 0;
        ScoreManager.scorePlayer2 = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
