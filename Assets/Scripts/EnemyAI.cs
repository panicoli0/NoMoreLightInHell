using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform rock;
    [SerializeField] float turnSpeed = 5.0f;

    public float chaceRange = 5.0f;

    private bool isProveked = false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    float distanceToRock = Mathf.Infinity;
    EnemyHealth health;
    Vector3 currentPos;

    public bool IsProveked { get => isProveked; set => isProveked = value; }


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

        //BackToDefaultPos();

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

    public void OnDamageTaken()
    {
        IsProveked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        //DetectTarget();
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

    public void RocksDetector()
    {
        rock = FindObjectOfType<Rock>().OnHitPos;
        FaceTarget();
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(rock.transform.position);
        //if (navMeshAgent.isStopped)
        //{
        //    GetComponent<Animator>().SetTrigger("Idle");
        //}
        
        ////BackToDefaultPos();
        //distanceToRock = Vector3.Distance(rock.transform.position, transform.position);
        //if (distanceToRock <= 7)
        //{
            
        //    //BackToDefaultPos();
        //}
        //GetComponent<Animator>().SetTrigger("Idle");
    }

    //private void BackToDefaultPos()
    //{
    //    if (rock == null)
    //    {
    //        navMeshAgent.SetDestination(currentPos);
    //        FaceTarget();
    //        GetComponent<Animator>().SetTrigger("Move");
    //    }

    //    GetComponent<Animator>().SetBool("Rest", true);
    //}

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
