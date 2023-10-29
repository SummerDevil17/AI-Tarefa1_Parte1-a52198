using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    [SerializeField] GameObject goal;
    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(goal.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
