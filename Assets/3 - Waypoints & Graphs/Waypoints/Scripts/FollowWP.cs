using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float trackerLookAhead = 10f;

    GameObject circuitTracker;
    int currentWaypointIndex = 0;

    void Start()
    {
        circuitTracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(circuitTracker.GetComponent<Collider>());
        circuitTracker.GetComponent<MeshRenderer>().enabled = false;

        circuitTracker.transform.position = this.transform.position;
        circuitTracker.transform.rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

        Quaternion lookAtRotation = Quaternion.LookRotation(circuitTracker.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(circuitTracker.transform.position, transform.position) > trackerLookAhead) { return; }

        if (Vector3.Distance(circuitTracker.transform.position, waypoints[currentWaypointIndex].position) < 3f)
        { currentWaypointIndex++; }

        if (currentWaypointIndex >= waypoints.Length)
        { currentWaypointIndex = 0; }

        circuitTracker.transform.LookAt(waypoints[currentWaypointIndex].position);
        circuitTracker.transform.Translate(0, 0, (speed + 50f) * Time.deltaTime);
    }
}
