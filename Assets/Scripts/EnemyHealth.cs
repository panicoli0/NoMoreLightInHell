using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100f;

    bool isDead;

    public bool IsDead { get => isDead; set => isDead = value; }
    public float EnemyHP { get => enemyHealth; set => enemyHealth = value; }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHealth = enemyHealth - damage;
        print(enemyHealth);
        if (enemyHealth <= 0)
        {
            //Destroy(gameObject);
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
