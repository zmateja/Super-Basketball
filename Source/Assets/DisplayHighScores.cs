using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Title;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text PlayerScore;
    public CanvasGroup Buttons;


    void Start()
    {
        Buttons.blocksRaycasts = false;
        Buttons.alpha = 0f;
        Title.text = "Congratulations!";
        StartCoroutine(ScoreCalc());
    }

    IEnumerator ScoreCalc()
    {
        string stars;
        string time;
        string deaths;
        if (uistuff.totalTime > 0)
        {
            deaths = "Total Deaths: " + uistuff.deaths + " x -500 = " + uistuff.deaths * -500;
            stars = "Total Stars: " + uistuff.numStars + " x 50 = " + uistuff.numStars * 50;
            time = "Total Time: " + uistuff.totalTime + " x 100 = " + (int)(uistuff.totalTime * 100);
            yield return new WaitForSeconds(2);
            Score1.text = time;
            yield return new WaitForSeconds(2);
            Score2.text = stars;
            yield return new WaitForSeconds(2);
            Score3.text = deaths;
            yield return new WaitForSeconds(2);

            PlayerScore.text = "Your Score: " + uistuff.score;
            yield return new WaitForSeconds(4);
        }

        Title.text = "High Scores";
        Score1.text = null;
        Score2.text = null;
        Score3.text = null;
        yield return new WaitForSeconds(1.5f);

        if (uistuff.score > PlayerPrefs.GetInt("HighScore3"))
            if (uistuff.score > PlayerPrefs.GetInt("HighScore2"))
                if (uistuff.score > PlayerPrefs.GetInt("HighScore1"))
                {
                    Score1.fontStyle = FontStyle.BoldAndItalic;
                    PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
                    PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("HighScore1"));
                    PlayerPrefs.SetInt("HighScore1", uistuff.score);
                }
                else
                {
                    Score2.fontStyle = FontStyle.BoldAndItalic;
                    PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
                    PlayerPrefs.SetInt("HighScore2", uistuff.score);
                }
            else
            {
                Score3.fontStyle = FontStyle.BoldAndItalic;
                PlayerPrefs.SetInt("HighScore3", uistuff.score);
            }
        else
        {
            Score1.fontStyle = FontStyle.Normal;
            Score2.fontStyle = FontStyle.Normal;
            Score3.fontStyle = FontStyle.Normal;
        }
        Score1.text = "1. " + PlayerPrefs.GetInt("HighScore1");
        yield return new WaitForSeconds(1.5f);
        Score2.text = "2. " + PlayerPrefs.GetInt("HighScore2");
        yield return new WaitForSeconds(1.5f);
        Score3.text = "3. " + PlayerPrefs.GetInt("HighScore3");

        Buttons.blocksRaycasts = true;
        Buttons.alpha = 1;


    }
}
