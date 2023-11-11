using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Link
{
    public enum Direction { UNI, BI }
    public GameObject node1, node2;
    public Direction linkDir;
}

public class WaypointsManager : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] Link[] links;
    [SerializeField] Graph graph = new();

    void Start()
    {
        if (waypoints.Length <= 0) { return; }

        foreach (GameObject wp in waypoints) { graph.AddNode(wp); }
        foreach (Link l in links)
        {
            graph.AddEdge(l.node1, l.node2);
            if (l.linkDir == Link.Direction.BI) { graph.AddEdge(l.node2, l.node1); }
        }

    }

    void Update()
    {

    }
}
