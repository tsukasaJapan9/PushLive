using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

public class MidiController : MonoBehaviour
{
    private int pad0 = 36;
    private int padNum = 16;
    public float[] padStatus = new float[16];

    void Start()
    {
        Debug.Log("ok");
    }

    /*
    public void GetPadStatus(bool[] status)
    {
        Array.Copy(this.padStatus, status, this.padStatus.Length);
    }
    */

    void Update()
    {
        for (int i = this.pad0; i < (this.pad0 + this.padNum); i++)
        {
            //bool value = MidiMaster.GetKeyDown(MidiChannel.Ch10, i);
            float value = MidiMaster.GetKey(MidiChannel.Ch10, i);
            int index = i - this.pad0;
            this.padStatus[index] = value;

            //Debug.Log(value);
            GameObject cube = GameObject.FindGameObjectWithTag("cube" + index);
            if (value > 0.5)
            {
                cube.GetComponent<CubeController>().SetYPos(1);

            }
            else
            {
                cube.GetComponent<CubeController>().SetYPos(0);

            }
        }
    }
}