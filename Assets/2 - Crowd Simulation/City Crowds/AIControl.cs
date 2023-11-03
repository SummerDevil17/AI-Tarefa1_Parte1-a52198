using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AIControl : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator animator;

    float startingSpeed;
    float randomSpeedMultiplier;
    float detectionRadius = 15f;
    float fleeRadius = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        goalLocations = GameObject.FindGameObjectsWithTag("Goal");

        animator.SetTrigger("isWalking");
        animator.SetFloat("wOffset", Random.Range(0f, 1f));

        startingSpeed = agent.speed;
        ResetToRandomDestination();
    }

    public void DetectNewObstacle(Vector3 obsPos)
    {
        if (Vector3.Distance(this.transform.position, obsPos) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - obsPos).normalized;
            Vector3 newDestination = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newDestination, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }

    void Update()
    {
        if (agent.remainingDistance < 1f) { ResetToRandomDestination(); }
    }

    private void ResetToRandomDestination()
    {
        randomSpeedMultiplier = Random.Range(0.2f, 1.5f);
        animator.SetFloat("speedMult", randomSpeedMultiplier);
        agent.speed = startingSpeed * randomSpeedMultiplier;
        agent.angularSpeed = 120;

        animator.SetTrigger("isWalking");

        agent.ResetPath();

        int i = Random.Range(0, goalLocations.Length);
        agent.SetDestination(goalLocations[i].transform.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectionRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, fleeRadius);
    }
}