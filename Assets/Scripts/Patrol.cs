using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol : MonoBehaviour
{
    public Transform[] points;

    [SerializeField] float patrolWaitingTime;

    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    private IEnumerator GotoNextPoint()
    {
        yield return new WaitForSeconds(patrolWaitingTime);
        // Returns if no points have been set up
        if (points.Length == 0)
            yield return new WaitForSeconds(0.1f);

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;

    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance <= 2f)
            StartCoroutine(GotoNextPoint());
    }
}