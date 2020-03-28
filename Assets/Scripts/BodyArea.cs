using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyArea : MonoBehaviour
{
    public BodyTrigger trigger;

    // Start is called before the first frame update

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject[] bodies = GameObject.FindGameObjectsWithTag("Body");
            foreach (GameObject body in bodies) { Destroy(body); }
            trigger.enabled = true;
}
    }
}
