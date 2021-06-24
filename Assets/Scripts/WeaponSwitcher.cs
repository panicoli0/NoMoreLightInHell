using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon;
    [SerializeField] Image[] selectedImage;

    private void Start()
    {
        SetWeaponActive();
    }

    private void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
                selectedImage[weaponIndex].gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
                selectedImage[weaponIndex].gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
