using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaDoor : MonoBehaviour
{
    public string DestinationScene;
    private bool flag = false;
    public string exitID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag && !Global.fadingOut)
        {
            SceneManager.LoadScene("loading");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Global.fadingOut = true;
            Global.nextScene = DestinationScene;
            flag = true;
            Global.exit = SceneManager.GetActiveScene().name + "_" + exitID;
        }
    }

}
