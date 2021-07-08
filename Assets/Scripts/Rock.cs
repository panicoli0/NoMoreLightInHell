using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float hitRange = 5.0f;

    Transform onHitPos;
    EnemyAI zombie = null;
    float distanceToClosestZombie = Mathf.Infinity;
    float impactRange = 3.0f;

    public Transform OnHitPos { get => onHitPos; set => onHitPos = value; }

    private void Awake()
    {
        FindNearestZombie();
    }

    private void FindNearestZombie()
    {
        EnemyAI[] zombies = FindObjectsOfType<EnemyAI>();

        foreach (EnemyAI currentZombie in zombies)
        {
            float distanceToZombie = (currentZombie.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToZombie < distanceToClosestZombie)
            {
                distanceToClosestZombie = distanceToZombie;
                zombie = currentZombie;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnHitPos = this.transform;
        //todo: Add RockHitSound
            //todo: Create a AudioListener ??

        var distanceToZombie = Vector3.Distance(zombie.transform.position, transform.position);

        if (distanceToZombie <= zombie.chaceRange)
        {
            zombie.RocksDetector(onHitPos);
        }
        Destroy(gameObject, 5.0f);
    }
}
