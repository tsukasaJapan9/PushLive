using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

namespace MidiJack
{
    public class Midicontroller : MonoBehaviour
    {
        private int pad1 = 36;
        private int padNum = 16;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("ok");
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = this.pad1; i < (this.pad1 + this.padNum); i++)
            {
                bool value = MidiMaster.GetKeyDown(MidiChannel.Ch10, i);
                if (value)
                {
                    Debug.Log("note:" + i.ToString());
                }
            }
        }
    }
}