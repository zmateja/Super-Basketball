using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickupObjects : MonoBehaviour
{
    public AudioSource PickupSound;
    public Text ScoreText;
    // Update is called once per frame
    int pickupValue = 50;


    void OnTriggerEnter(Collider col)
    {
        PickupSound.Play();
        uistuff.score += pickupValue;
        uistuff.numStars += 1;
        ScoreText.text = "Score: " + uistuff.score;
        Destroy(gameObject);
    }
}
