using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField] WaypointsManager WPManagerReference;

    [Header("Movement Variables")]
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] float accuracy = 1f;

    GameObject[] waypoints;
    GameObject currentNode;
    int currentWaypoint = 0;
    Graph graph;

    Transform goal;

    void Start()
    {
        waypoints = WPManagerReference.waypoints;
        graph = WPManagerReference.graph;
        currentNode = waypoints[currentWaypoint];
    }

    void Update()
    {

    }

    public void GoToHelipad()
    {
        graph.AStar(currentNode, waypoints[waypoints.Length - 1]);
        currentWaypoint = 0;
    }

    public void GoToRuin()
    {
        graph.AStar(currentNode, waypoints[4]);
        currentWaypoint = 0;
    }
}
