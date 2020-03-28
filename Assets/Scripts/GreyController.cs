using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyController : MonoBehaviour
{

    private CRTEffect effects;
    private bool greyscaleMonitor;
    // Start is called before the first frame update
    void Start()
    {
        effects = GetComponent<CRTEffect>();
    }

    private void Update()
    {

        if (greyscaleMonitor != Global.greyscale) {
            if (Global.greyscale)
            {
                effects.saturation += -0.5f;
                effects.whiteNoiseStrength += 0.8f;
                effects.chromaticAberrationOffset += -.25f;
            }
        else
            {
                effects.saturation -= -0.5f;
                effects.whiteNoiseStrength -= 0.8f;
                effects.chromaticAberrationOffset -= -.25f;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        greyscaleMonitor = Global.greyscale;
    }
}
