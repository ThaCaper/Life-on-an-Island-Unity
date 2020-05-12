﻿using UnityEngine;

public class shiftCamera : MonoBehaviour
{

    public Camera mainCamera;

    public Camera CameraTwo;

    public bool maincam = true;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = maincam;
        CameraTwo.enabled = !maincam;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            maincam = !maincam;
            mainCamera.enabled = maincam;
            CameraTwo.enabled = !maincam;
        }
    }
}
