using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BateryBar : MonoBehaviour
{
    [SerializeField] Image batteryFillImage;
    [SerializeField] Light batteryAmount;

    float currentBattery;
    float maxBattery;

    // Start is called before the first frame update
    void Start()
    {
        maxBattery = batteryAmount.intensity; 
    }

    // Update is called once per frame
    void Update()
    {
        currentBattery = FindObjectOfType<FlashlightLifetime>().FlashLight.intensity;
        batteryFillImage.fillAmount = currentBattery / maxBattery;
    }
}
