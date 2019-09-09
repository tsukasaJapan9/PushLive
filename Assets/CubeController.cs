using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameObject midiconObj;
    private MidiController midicon;

    // Start is called before the first frame update
    void Start()
    {
        this.midiconObj = GameObject.Find("MidiController");
        midicon = this.midicon.GetComponent<MidiController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(midicon.padStatus);
    }
}
