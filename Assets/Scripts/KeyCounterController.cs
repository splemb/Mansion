using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounterController : MonoBehaviour
{

    public TMPro.TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = Global.keyCount.ToString();
    }
}
