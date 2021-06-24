using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Rigidbody rock;
    [SerializeField] Transform throwPoint;
    [SerializeField] int rockSpeed;

    //todo: Add audio clips

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowEvent();
        }
    }

    private void ThrowEvent()
    {
        Rigidbody rockInstance;
        rockInstance = Instantiate(rock, throwPoint.position, throwPoint.rotation);
        rockInstance.AddForce(throwPoint.forward * rockSpeed);
        //Destroy(rockInstance.gameObject, 3f);
    }

    //todo: Calcular con el raycast donde cae la piedra

    //todo: Hacer que el zombie vaya a la pos donde cayo la piedra
    // Create a zombieSoundListener ??
    //Piedras caen en una pos.
    //si cae en el chaceRange(soundChaceRange?) del zombie. El zombie debe ir a esa posicion

}
