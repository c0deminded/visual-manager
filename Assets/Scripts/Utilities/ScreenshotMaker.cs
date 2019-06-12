using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotMaker : MonoBehaviour
{

    public string path;
    public int scaleMult = 3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            ScreenCapture.CaptureScreenshot(path, scaleMult);
    }



}
