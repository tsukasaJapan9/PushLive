using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public RadiationBlur radiationBlur;
    GameObject midiControllerObj;
    MidiController midiController;

    KeyCode radiationBlurKey = KeyCode.F1;
    public float maxRadiationBlurPower = 150;
    public float effectTime = 0.25f;

    void Reset() 
    {
        radiationBlur.power = 0;
    }

    void Start()
    {
        this.midiControllerObj = GameObject.Find("MidiController");
        this.midiController = this.midiControllerObj.GetComponent<MidiController>();

        Reset(); 
    }


    void Update()
    {
        KeyCheck();
        MidiCheck();
    }

    IEnumerator StartRadiationBlur() 
    {
        Debug.Log("test");
        float duration = effectTime;
        while (duration > 0f) 
        {
            duration = Mathf.Max(duration - Time.deltaTime, 0);
            var inOutType = EasingLerps.EasingInOutType.EaseOut;
            var type = EasingLerps.EasingLerpsType.Quad;
            radiationBlur.power = EasingLerps.EasingLerp(
                type, inOutType, duration, 0, 1) * maxRadiationBlurPower;
            yield return null;
        }
    }

    void KeyCheck() 
    {
        if (Input.GetKeyDown(radiationBlurKey)) {
            StartCoroutine(StartRadiationBlur());
        }
    }

    void MidiCheck()
    {
        if (this.midiController.padStatus[6] == true) {
            StartCoroutine(StartRadiationBlur());
        }
    }
}
