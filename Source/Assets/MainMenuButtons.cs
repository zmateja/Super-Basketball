using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
        uistuff.score = 0;
        uistuff.deaths = 0;
        uistuff.totalTime = 0;
        uistuff.numStars = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        uistuff.score = 0;
        uistuff.deaths = 0;
        uistuff.totalTime = 0;
        uistuff.numStars = 0;
    }
    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");

    }
}
