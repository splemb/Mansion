using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Interaction
{

    private AudioSource sound;
    private bool flag = false;
    private string ID;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        try
        {
            ID = GetComponent<UniqueID>().ID;
            if (Global.CheckUsed(ID))
            {
                Destroy(gameObject);
            }
        }
        catch
        {
            Debug.LogError("OBJECT HAS NO ID BUT SHOULD!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!sound.isPlaying && flag)
        {
            Destroy(gameObject);
        }
    }

    public override void OnInteract()
    {
        
        flag = true;
        sound.Play();
        Global.keyCount++;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Global.usedObjects.Add(ID);
        
    }

    public override string OnLookAt()
    {
        return ("PICK UP");
    }
}
