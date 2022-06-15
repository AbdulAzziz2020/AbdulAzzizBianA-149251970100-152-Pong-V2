using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScene : MonoBehaviour
{
    [Header("Universal")]
    public float duration = 2f;
    public GameObject transition;
    private Animator anim;

    [Header("For Main Menu")]
    [SerializeField]
    private TMP_InputField setMaxScore;
    [SerializeField]
    private TMP_Text placeHolder;

    private void Start()
    {
        anim = transition.GetComponent<Animator>();
    }

    #region Scene Manager
    public void Play()
    {
        if(string.IsNullOrEmpty(setMaxScore.text))
        {
            placeHolder.text = "Please fill max score!";
        }
        else
        {
            StartCoroutine(Transition("Game"));

            ScoreManager.scorePlayer1 = 0;
            ScoreManager.scorePlayer2 = 0;

            int maxScore = int.Parse(setMaxScore.text);
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }
    }

    public void Restart()
    {
        StartCoroutine(Transition("Game"));

        ScoreManager.scorePlayer1 = 0;
        ScoreManager.scorePlayer2 = 0;
    }

    public void Home()
    {
        StartCoroutine(Transition("Main Menu"));
    }

    public void Credit()
    {
        StartCoroutine(Transition("Credit"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MoreGames(string url)
    {
        Application.OpenURL(url);
    }
    #endregion

    IEnumerator Transition(string sceneName)
    { 
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(sceneName);

    }
}
