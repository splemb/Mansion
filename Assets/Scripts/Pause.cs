using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;

    public AudioMixer Mixer;
    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot Paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("START"))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
                Paused.TransitionTo(0f);
            } else
            {
                Time.timeScale = 1f;
                isPaused = false;
                Normal.TransitionTo(0f);
            }
        }
    }
}
