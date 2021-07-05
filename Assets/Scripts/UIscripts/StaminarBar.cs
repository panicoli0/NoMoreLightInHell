using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using static UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController;

public class StaminarBar : MonoBehaviour
{
    [SerializeField] Image staminaFillImage;
    [SerializeField] float maxStamina = 1.0f;
    [SerializeField] float staminaDecay = 1.0f;
    [SerializeField] float recoveryTime = 2.0f;
    [SerializeField] AudioSource footStepSound;

    RigidbodyFirstPersonController instance;
    float currentStamina;
    float staminaDecremental;
    float staminaIncremental;
    float minStamina;

    private void Awake()
    {
        currentStamina = maxStamina;
        instance = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()       
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DecreaseStamina();
        }
        else
        {
            IncreaseStamina();
            footStepSound.enabled = false;

        }
    }

    private void DecreaseStamina()
    {
        minStamina = 0.01f;
        if (staminaFillImage.fillAmount <= minStamina)
        {
            instance.movementSettings.RunMultiplier = 1.0f;
            footStepSound.enabled = false;
            //todo: add tiredAudio
        }
        else
        {
            footStepSound.enabled = true;
        }
        staminaDecremental = staminaDecay * Time.deltaTime;
        staminaFillImage.fillAmount -= staminaDecremental;
    }

    private void IncreaseStamina()
    {
        if (staminaFillImage.fillAmount >= maxStamina)
        {
            instance.movementSettings.RunMultiplier = 2.0f;
            //todo: add tiredAudio
            return;
        }
        staminaIncremental = (staminaDecay / recoveryTime) * Time.deltaTime;
        staminaFillImage.fillAmount += staminaIncremental;
    }
}
