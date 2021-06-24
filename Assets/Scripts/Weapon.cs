using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCam;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem flashFX;
    [SerializeField] GameObject onHitFX;
    [SerializeField] float timeBeetwenShoots = 0.5f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float ammoDecrease = 1f;

    //private int ammoAmount;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }  
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            PlayShootFX();
            ProcessRaycast();
            ammoSlot.DecreaseAmmo(ammoType, ammoDecrease);
        }
        yield return new WaitForSeconds(timeBeetwenShoots);
        canShoot = true;
    }

    private void PlayShootFX()
    {
        if (flashFX == null) return;

        flashFX.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (FPCam == null) return;
        var hitSomething = Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit, range);

        if (hitSomething)
        {
            CreateImpactFX(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateImpactFX(RaycastHit hit)
    {
        var impact = Instantiate(onHitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}

