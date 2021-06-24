using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomIn = 30.0f;
    [SerializeField] float zoomOut = 60.0f;

    bool zoomInToggle = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (zoomInToggle == false)
            {
                zoomInToggle = true;
                fpsCamera.fieldOfView = zoomIn;
            }
            else
            {
                zoomInToggle = false;
                fpsCamera.fieldOfView = zoomOut;
            }
        }
    }

    private void OnDisable()
    {
        fpsCamera.fieldOfView = zoomOut;
    }
}
