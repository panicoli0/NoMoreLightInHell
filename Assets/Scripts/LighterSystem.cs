using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterSystem : MonoBehaviour
{

    
    [SerializeField] float lightIntensity = 3f;
    [SerializeField] float minimunIntensity = 0.1f;
    [SerializeField] float intensityDecay = 1;
    [SerializeField] ParticleSystem flame;
    [SerializeField] Light flameLight;

    private void Start()
    {
        flameLight.intensity = minimunIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FlameIntensity();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FlameDecremental();
        }
    }

    private void FlameDecremental()
    {
        flame.Stop();
        //lightIntensity = intensityDecay * Time.deltaTime;
        flameLight.intensity = minimunIntensity;
    }

    private void FlameIntensity()
    {
        flame.Play();
        flameLight.intensity = lightIntensity;
    }
}
