using UnityEngine;
using System.Collections;

public class flareround : MonoBehaviour
{
    private GameObject flaregun;
    [SerializeField] Flaregun flare;
    public AudioClip pickupSound;

    // Use this for initialization
    void Start()
    {
        flaregun = GameObject.Find("flaregun");
        //flare = flaregun.GetComponent<Flaregun>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && flare.spareRounds < flare.maxSpareRounds)
        {
            GetComponent<AudioSource>().PlayOneShot(pickupSound);
            flare.spareRounds++;
            Destroy(this.gameObject, pickupSound.length);
        }

    }
}

