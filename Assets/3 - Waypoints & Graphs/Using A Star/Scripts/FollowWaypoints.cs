using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField] WaypointsManager WPManagerReference;

    [Header("Movement Variables")]
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] float accuracy = 5f;

    GameObject[] waypoints;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;

    Transform goal;

    void Start()
    {
        waypoints = WPManagerReference.waypoints;
        graph = WPManagerReference.graph;
        currentNode = waypoints[currentWaypointIndex];

        Invoke("GoToRuin", 2f);
    }

    void LateUpdate()
    {
        if (graph.pathList.Count == 0 || currentWaypointIndex == graph.pathList.Count) { return; }

        if (Vector3.Distance(transform.position, graph.pathList[currentWaypointIndex].GetObjID().transform.position) < accuracy)
        {
            currentNode = graph.pathList[currentWaypointIndex].GetObjID();
            currentWaypointIndex++;
        }
        if (currentWaypointIndex < graph.pathList.Count)
        {
            goal = graph.pathList[currentWaypointIndex].GetObjID().transform;

            Vector3 goalToLookAt = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 goalDirection = goalToLookAt - transform.position;

            transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(goalDirection), rotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoToHelipad()
    {
        graph.AStar(currentNode, waypoints[waypoints.Length - 1]);
        currentWaypointIndex = 0;
    }

    public void GoToRuin()
    {
        graph.AStar(currentNode, waypoints[4]);
        currentWaypointIndex = 0;
    }

    public void GoToMill()
    {
        graph.AStar(currentNode, waypoints[11]);
        currentWaypointIndex = 0;
    }

    public void GoToSkeleton()
    {
        graph.AStar(currentNode, waypoints[0]);
        currentWaypointIndex = 0;
    }
}
