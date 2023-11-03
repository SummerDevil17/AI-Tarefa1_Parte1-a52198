using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField] float speed = 10f;

    int currentWaypointIndex = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 3f)
        { currentWaypointIndex++; }

        if (currentWaypointIndex >= waypoints.Length)
        { currentWaypointIndex = 0; }

        transform.LookAt(waypoints[currentWaypointIndex].position);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}