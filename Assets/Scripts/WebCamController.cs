using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamController : MonoBehaviour
{
    // private int width = 1280;
    // private int height = 720;
    private int width = 640;
    private int height = 480;

    private int fps = 30;
    private WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        foreach (WebCamDevice device in devices)
        {
            Debug.Log("WebCamDevice " + device.name);
        }
        // webcamTexture = new WebCamTexture(this.width, this.height, this.fps);
        // GetComponent<Renderer>().material.mainTexture = webcamTexture;
        // webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
