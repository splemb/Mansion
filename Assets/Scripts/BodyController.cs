using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : Interaction
{
    //Variables
    private AudioSource sound;
    public GameObject model;
    private Transform playerPos;

    public bool JumpBack;
    public bool JumpRight;
    public bool JumpLeft;
    public bool JumpForward;
    public float JumpSpeed;
    public bool LookAtPlayer;
    public bool FollowPlayer;
    public bool FollowOnLook;
    public bool DestroyOnLook;

    public float lifetime;
    public float FollowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        playerPos = (GameObject.FindGameObjectsWithTag("Player"))[0].GetComponent<Transform>();
        Global.greyscale = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (LookAtPlayer)
        {
            
        }
        if (FollowPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position,FollowSpeed);
        }

        transform.LookAt(playerPos);
    }

    public override string OnLookAt()
    {
                if (FollowOnLook)
        {
            FollowPlayer = true;
        }
        if (DestroyOnLook)
        {
            Destroy(gameObject);
        }
        

        if (lifetime != -1) { Destroy(gameObject, lifetime); }
        
        return ("HELP ME");
    }

    public void OnDestroy()
    {
        Global.greyscale = false;
    }

}
