using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Global
{
    public static int keyCount = 0;
    public static bool fadingIn = false;
    public static bool fadingOut = false;
    public static float fadeAmount = 0f;
    public static float fadeSpeed = 0.05f;

    public static bool greyscale = false;
    public static string nextScene = "title";
    public static float loadTime = 3f;

    public static string exit = "title_00";

    public static bool showGhostMessage = false;
    

    public static List<string> usedObjects = new List<string>();

    public static bool CheckUsed(string ID)
    {
        foreach (string Object in usedObjects) {
            if (Object == ID)
            {
                return true;
            }
        }
        return false;
    }

    public static void Timer(ref float timer, float timerMax, ref bool flag, bool result)
    {
        if (timer == timerMax)
        {
            return;
        }
        else if (timer < timerMax)
        {
            timer += Time.deltaTime;
            flag = !result;
        }
        else
        {
            timer = timerMax;
            flag = result;
        }
    }
}

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    
}
