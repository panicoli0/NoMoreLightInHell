using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public float ammoAmount;
        public float ammoAngleAmount;
    }

    public void DecreaseAmmo(AmmoType ammoType, float ammoDecrease)
    {
        GetAmmoSlot(ammoType).ammoAmount -= ammoDecrease;
    }

    public void IncreaseAmmo(AmmoType ammoType, float ammoAmountIncremental)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmountIncremental;
    }

    public float GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
