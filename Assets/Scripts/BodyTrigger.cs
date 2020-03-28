using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTrigger : MonoBehaviour
{
    //Variables
    public BodyController Body;
    public Transform bodySpawn;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Body, bodySpawn.position, Quaternion.identity);
            GetComponent<BoxCollider>().enabled = false;

            //GetComponent<AudioSource>().Play();
        }
    }
    

}
