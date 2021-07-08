using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform hitPos;
    public float chaceRange = 5.0f;
    public bool IsProveked { get => isProveked; set => isProveked = value; }

    [SerializeField] float turnSpeed = 5.0f;

    NavMeshAgent navMeshAgent;
    private bool isProveked = false;
    bool isPersuing = false;
    float distanceToTarget = Mathf.Infinity;
    float distanceToRock = Mathf.Infinity;
    EnemyHealth health;
    Vector3 currentPos;

    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        StartCoroutine(PersueDetector());

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (IsProveked)
        {
            EngageTarget();

        }
        else if (distanceToTarget <= chaceRange)
        {
            IsProveked = true;
        }
    }

    private IEnumerator PersueDetector()
    {
        if (isPersuing && navMeshAgent.remainingDistance <= 1.5f)
        {
            GetComponent<Animator>().SetTrigger("Idle");
        }

        yield return new WaitForSeconds(2.0f);
    }

    public void OnDamageTaken()
    {
        IsProveked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    public void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    public void RocksDetector(Transform hitPos)
    {
        distanceToRock = Vector3.Distance(hitPos.position, transform.position);

        if (hitPos != null)
        {
            isPersuing = true;
            GetComponent<Animator>().SetTrigger("Move");
            navMeshAgent.SetDestination(hitPos.position);
        }
        else if (distanceToRock <= navMeshAgent.stoppingDistance)
        {
            isPersuing = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaceRange);
    }

    private void FaceTarget()
    {
        var direction = (target.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

    }
}
