using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoad : MonoBehaviour
{
    public CanvasGroup title;
    public CanvasGroup buttons;

    // Start is called before the first frame update
    void Start()
    {
        title.alpha = 0;
        buttons.alpha = 0;
        title.blocksRaycasts = false;
        buttons.blocksRaycasts = false;
        Invoke("FadeIn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(title.alpha < 1)
        {
            title.alpha += .01f;
        }
        else if(buttons.alpha < 1)
            buttons.alpha += .01f;
        else
        {
            title.blocksRaycasts = true;
            buttons.blocksRaycasts = true;
        }


    }
}
