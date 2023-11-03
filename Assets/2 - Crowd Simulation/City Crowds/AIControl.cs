using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{

    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        goalLocations = GameObject.FindGameObjectsWithTag("Goal");

        SetRandomDestination();
        animator.SetTrigger("isWalking");
    }

    void Update()
    {
        if (agent.remainingDistance < 1f) { SetRandomDestination(); }
    }

    private void SetRandomDestination()
    {
        int i = Random.Range(0, goalLocations.Length);
        agent.SetDestination(goalLocations[i].transform.position);
    }
}