using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    //Variables
    private float loadTimer;
    public Slider loadbar;

    // Start is called before the first frame update
    void Start()
    {
        loadTimer = Global.loadTime / 2;
        Global.fadeAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        loadbar.value = 1 - loadTimer / Global.loadTime;
        if (loadTimer <= 0) {
            SceneManager.LoadScene(Global.nextScene);
        } else
        {
            loadTimer -= Time.deltaTime;
        }

    }
}
