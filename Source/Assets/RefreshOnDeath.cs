using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RefreshOnDeath : MonoBehaviour
{
    public Text scoreText;
    public Text deathText;

    void OnTriggerEnter(Collider player)
    {
        uistuff.deaths += 1;
        uistuff.score -= 500;
        uistuff.timerEnable = false;
        Ballstuff.canMove = false;
        deathText.text = "Deaths: " + uistuff.deaths;
        scoreText.text = "Score: " + uistuff.score;
        Scene curscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curscene.name);
    }
    
}
