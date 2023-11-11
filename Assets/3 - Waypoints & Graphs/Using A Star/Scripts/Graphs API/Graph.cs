using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Edge> edges = new List<Edge>();
    List<Node> nodes = new List<Node>();
    List<Node> pathsList = new List<Node>();

    public Graph() { }

    /// <summary>
    /// Creates a new Node and adds it to the tracked Node List.
    /// </summary>
    /// <param name="newNode"></param>
    public void AddNode(GameObject newNode)
    {
        Node node = new Node(newNode);
        nodes.Add(node);
    }

    /// <summary>
    /// Creates a new Edge, from two GameObjects and between two existing Nodes, adding it to the Edges List.
    /// </summary>
    /// <param name="fromObj"></param>
    /// <param name="toObj"></param>
    public void AddEdge(GameObject fromObj, GameObject toObj)
    {
        Node from = FindNode(fromObj);
        Node to = FindNode(toObj);

        if (from == null || to == null) return;

        Edge edge = new Edge(from, to);
        edges.Add(edge);

        from.edgeList.Add(edge);
    }

    private Node FindNode(GameObject toFind)
    {
        foreach (Node node in nodes)
        {
            if (node.GetObjID() == toFind) { return node; }
        }
        return null;
    }


}
