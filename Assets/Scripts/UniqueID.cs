using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniqueID : MonoBehaviour
{
    public string ID;
    // Start is called before the first frame update
    void Start()
    {
        ID = (SceneManager.GetActiveScene().name + "." + GetComponent<Transform>().position.sqrMagnitude.ToString());
    }
}
