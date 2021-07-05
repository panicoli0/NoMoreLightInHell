using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Transform onHitPos;

    EnemyAI zombie;
    float impactRange = 3.0f;

    public Transform OnHitPos { get => onHitPos; set => onHitPos = value; }

    private void Start()
    {
        zombie = FindObjectOfType<EnemyAI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnHitPos = this.transform;
        zombie.RocksDetector(onHitPos);

        var distanceToZombie = Vector3.Distance(zombie.transform.position, transform.position);

        if (distanceToZombie <= zombie.chaceRange)
        {
            zombie.RocksDetector(onHitPos);
        }
        Destroy(gameObject, 5.0f);
    }
}
