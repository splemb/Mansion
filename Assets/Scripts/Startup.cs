using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!Application.isEditor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            flag = true;
        }

        else if (!GetComponent<VideoPlayer>().isPlaying && flag)
        {
            Global.nextScene = "title";
            Global.loadTime = 3f;
            SceneManager.LoadScene("loading");
        }
    }
}
