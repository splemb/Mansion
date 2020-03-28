using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string state = "";

    // Start is called before the first frame update
    void Start()
    {
        Global.fadeAmount = 2;
        Global.fadingIn = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "newgame")
        {
            if (!Global.fadingOut)
            {
                SceneManager.LoadScene("loading");
            }
        }
    }


    public void NewGame()
    {
        Global.fadingOut = true;
        Global.nextScene = "Area01";
        Global.loadTime = 5f;
        state = "newgame";
    }

}
