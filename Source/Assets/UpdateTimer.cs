using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateTimer : MonoBehaviour
{

    public Text timerText;
    public Text scoreText;
    public Text deathText;
    public Text countdownText;
    [SerializeField] private float timerStart = 60.00f;
    private float curTime;
    int count = 3;
    // Start is called before the first frame update
    void Start()
    {
        uistuff.numStars = 0;
        curTime = timerStart;
        scoreText.text = "Score: " + uistuff.score;
        deathText.text = "Deaths: " + uistuff.deaths;
        timerText.text = "" + curTime;
        Countdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (uistuff.timerEnable == true && curTime > 0)
        {
            curTime = curTime - .02f;
            timerText.text = "" + curTime;
        }
        else if(curTime <= 0)
        {
            countdownText.text = "TIME UP!";
            Ballstuff.canMove = false;
            uistuff.timerEnable = false;
            Invoke("TimesUp", 2);
        }

    }

    void TimesUp()
    {
        uistuff.deaths += 1;
        uistuff.score -= 500;
        deathText.text = "Deaths: " + uistuff.deaths;
        scoreText.text = "Score: " + uistuff.score;
        Scene curscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curscene.name);
    }

    void Countdown()
    {
        countdownText.text = "" + count;
        count--;
        if (count > 0)
            Invoke("Countdown", 1);
        else
            StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        yield return new WaitForSeconds(1);
        uistuff.timerEnable = true;
        countdownText.text = "GO!";
        Ballstuff.canMove = true;
        yield return new WaitForSeconds(1);
        countdownText.text = null;
    }

}
