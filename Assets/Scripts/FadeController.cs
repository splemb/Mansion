using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    //Variables
    //private PSXEffects effects;
    private CanvasGroup group;

    // Start is called before the first frame update
    void Start()
    {
        //effects = GetComponent<PSXEffects>();
        group = GetComponent<CanvasGroup>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.fadingIn)
        {
            if (Global.fadeAmount > 0f)
            {
                Global.fadeAmount-=Global.fadeSpeed;
                Time.timeScale = 0f;
            } else
            {
                Global.fadeAmount = 0;
                Global.fadingIn = false;
                Time.timeScale = 1f;
            }
        }

        if (Global.fadingOut)
        {
            if (Global.fadeAmount < 1)
            {
                Global.fadeAmount+= Global.fadeSpeed;
                Time.timeScale = 0f;
            }
            else
            {
                Global.fadeAmount = 1;
                Global.fadingOut = false;
                Time.timeScale = 1f;
            }
        }

        group.alpha = Global.fadeAmount;
        Debug.Log(Global.fadeAmount);
    }
}
