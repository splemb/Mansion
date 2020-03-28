using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterVolume;
    public Slider sfxVolume;
    public Slider musicVolume;
    public Slider uiVolume;

    public void Start()
    {
        masterVolume.value = GetVolume("MasterVolume");
        //sfxVolume.value = GetVolume("SFXVolume");
        musicVolume.value = GetVolume("MusicVolume");
        //uiVolume.value = GetVolume("UIVolume");
    }

    public void UpdateVolume()
    {
        mixer.SetFloat("MasterVolume", masterVolume.value);
        //mixer.SetFloat("SFXVolume", sfxVolume.value);
        mixer.SetFloat("MusicVolume", musicVolume.value);
        //mixer.SetFloat("UIVolume", uiVolume.value);
    }

    public float GetVolume(string parameter)
    {
        float value;
        bool result = mixer.GetFloat(parameter, out value);
        if (result)
        {
           return value;
        }
        else
        {
            return 0f;
        }
    }


}
