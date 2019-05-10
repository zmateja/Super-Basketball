using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelComplete : MonoBehaviour
{
    public AudioSource Fanfare;
    public Text ScoreText;
    public Text TimerText;
    private float score;

    void OnTriggerEnter(Collider player)
    {
        uistuff.timerEnable = false;
        score = float.Parse(TimerText.text);
        uistuff.totalTime += score;
        score = score * 100 + uistuff.score;
        uistuff.score = Mathf.RoundToInt(score);
        ScoreText.text = "Score: " + uistuff.score;

        Ballstuff.canMove = false;
        Fanfare.Play();

        
        Invoke("nextLevel", 3);
    }

    void nextLevel()
    { 
        Scene curscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curscene.buildIndex + 1);
    }

}
