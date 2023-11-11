using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public Node startNode;
    public Node endNode;

    /// <summary>
    /// Creates an edge between two given nodes.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public Edge(Node from, Node to)
    {
        startNode = from;
        endNode = to;
    }
}
