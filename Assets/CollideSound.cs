using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSound : MonoBehaviour
{
    private AudioSource asrc;

    void Start()
    {
        asrc = GetComponent(typeof(AudioSource)) as AudioSource;
    }
    void OnCollisionEnter(Collision other)
    {
        if (asrc != null)
        {
            asrc.Play();
        }
    }
}
