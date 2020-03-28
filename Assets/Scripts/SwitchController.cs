using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : Interaction
{

    public DoorController door;

    public override string OnLookAt()
    {
        return ("PRESS");
    }

    public override void OnInteract()
    {
        door.locked = false;
        door.open = true;

        GetComponent<AudioSource>().Play();
    }
}
