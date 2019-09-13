using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private int yPos = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetYPos(int p)
    {
        this.yPos = p;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = this.yPos;
        gameObject.transform.position = pos;
    }
}
