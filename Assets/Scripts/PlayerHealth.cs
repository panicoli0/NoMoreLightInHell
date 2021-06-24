using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float playerHealth = 100f;

    public float PlayerHP { get => playerHealth; set => playerHealth = value; }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        //todo: create DrainDamage()
        if (playerHealth <= 0)
        {
            FindObjectOfType<EnemyAI>().IsProveked = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void DrainDamage()
    {
        //todo: continue drainig player HP like he is infected
    }
}