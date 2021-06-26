using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Transform onHitPos;
    //[SerializeField] float area = 5.0f;

    EnemyAI zombie;

    public Transform OnHitPos { get => onHitPos; set => onHitPos = value; }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        //print(transform.position);
        OnHitPos = this.transform;
        if (gameObject.activeInHierarchy)
        {
            zombie = FindObjectOfType<EnemyAI>();
            zombie.RocksDetector();
        }
        //Destroy(gameObject, 5f);
        yield break;
    }
}
