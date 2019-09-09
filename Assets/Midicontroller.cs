using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

public class MidiController : MonoBehaviour
{
    private int pad1 = 36;
    private int padNum = 16;
    public bool[] padStatus = new bool[16];

    void Start()
    {
        Debug.Log("ok");
    }

    public void GetPadStatus(bool[] status)
    {
        Array.Copy(this.padStatus, status, this.padStatus.Length);
    }

    void Update()
    {
        for (int i = this.pad1; i < (this.pad1 + this.padNum); i++)
        {
            bool value = MidiMaster.GetKeyDown(MidiChannel.Ch10, i);
            this.padStatus[i - this.pad1] = value;
            if (value)
            {
                Debug.Log("note:" + i.ToString());
            }
        }
    }
}