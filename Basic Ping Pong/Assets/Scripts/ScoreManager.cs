using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Controller")]
    public int setWinningScore = 9;
    
    [Header("Panel Controller")]
    public TMP_Text winnerText;
    public GameObject startPanel;
    public GameObject finishPanel;

    [Header("Player 1 Controller")]
    public TMP_Text scorePlayer1Text;
    public TMP_Text player1MatchPoint;

    [Header("Player 2 Controller")]
    public TMP_Text scorePlayer2Text;
    public TMP_Text player2MatchPoint;

    public static int scorePlayer1 = 0;
    public static int scorePlayer2 = 0;
    public static bool isGameEnded = true;

    private void Start()
    {
        scorePlayer1Text.text = scorePlayer1.ToString();
        scorePlayer2Text.text = scorePlayer2.ToString();
        setWinningScore = PlayerPrefs.GetInt("MaxScore");
    }

    private void Update()
    {
        StartCoroutine(ScorePlayer1());
        StartCoroutine(ScorePlayer2());
    }

    IEnumerator ScorePlayer1()
    {
        scorePlayer1Text.text = scorePlayer1.ToString();
        if(scorePlayer1 == setWinningScore - 1)
        {
            player1MatchPoint.gameObject.SetActive(true);
        }

        if (scorePlayer1 == setWinningScore)
        {
            isGameEnded = true;

            yield return new WaitForSeconds(2f);

            finishPanel.SetActive(true);
            winnerText.text = "Player 1, Won!";
        }
    }

    IEnumerator ScorePlayer2()
    {
        scorePlayer2Text.text = scorePlayer2.ToString();
        if (scorePlayer2 == setWinningScore - 1)
        {
            player2MatchPoint.gameObject.SetActive(true);
        }

        if (scorePlayer2 == setWinningScore)
        {
            isGameEnded = true;

            yield return new WaitForSeconds(2f);

            finishPanel.SetActive(true);
            winnerText.text = "Player 2, Won";
        }
    }

    public void PlayGame()
    {
        isGameEnded = false;
        startPanel.SetActive(false);

        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        ball.GetComponent<BallController>().Start();
    }
}
