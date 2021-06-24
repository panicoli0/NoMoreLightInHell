using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightLifetime : MonoBehaviour
{
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float intensityDecay = 1f;
    [SerializeField] float minimunAngle = 40f;
    //[SerializeField] Ammo ammoSlot;
    //[SerializeField] AmmoType ammoType;

    float angleDecremental;
    float ammoDecremental;
    Light flashLight;

    public Light FlashLight { get => flashLight; set => flashLight = value; }

    // Start is called before the first frame update
    void Start()
    {
        FlashLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreseaseLight();
        DecreaseAngle();
    }

    private void DecreaseAngle()
    {

        if (FlashLight.spotAngle <= minimunAngle)
        {
            return;
        }
        angleDecremental = angleDecay * Time.deltaTime;
        FlashLight.spotAngle -= angleDecremental;
    }

    public void RestoreAngle(float lightAngle)
    {
        FlashLight.spotAngle = lightAngle;
    }

    private void DecreseaseLight()
    {
        var minumunIntensity = 0.1;
        if (FlashLight.intensity <= minumunIntensity)
        {
            return;
        }
        ammoDecremental = intensityDecay * Time.deltaTime;
        FlashLight.intensity -= ammoDecremental;
    }

    public void AddLightIntensity(float lightIntensity)
    {
        FlashLight.intensity += lightIntensity;
    }
}
