using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
    }
}
