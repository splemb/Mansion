using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMessage : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    private TMPro.TextMeshProUGUI textMesh;
    public float timerMax;
    private float timer;
    public string[] ghostMessages = new string[]
    {"you shouldnt be here",
        "stop trying",
        "THEY will not be so merciful",
        "TURN OFF THE CONSOLE" };
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Global.showGhostMessage + " - " + timer);
        if (Global.showGhostMessage)
        {
            flag = true;
            int messageIndex = rnd.Next(ghostMessages.Length);
            textMesh.text = ghostMessages[messageIndex];
            textMesh.enabled = true;
            
            Global.showGhostMessage = false;
        }

        if (flag)
        {
            Global.Timer(ref timer, timerMax, ref flag, false);
        } else
        {
            timer = 0;
            textMesh.enabled = false;
        }
    }
}
