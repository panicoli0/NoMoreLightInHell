using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Image playerFillImage;

    float currentHP;
    float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = FindObjectOfType<PlayerHealth>().PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = FindObjectOfType<PlayerHealth>().PlayerHP;
        playerFillImage.fillAmount = currentHP / maxHP;
    }
}
