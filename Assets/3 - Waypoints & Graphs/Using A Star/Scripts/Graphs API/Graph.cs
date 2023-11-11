using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Edge> edges = new List<Edge>();
    List<Node> nodes = new List<Node>();
    public List<Node> pathList = new List<Node>();

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

    public bool AStar(GameObject startObj, GameObject endObj)
    {
        if (startObj == endObj) { pathList.Clear(); return false; }

        Node start = FindNode(startObj);
        Node end = FindNode(endObj);

        if (start == null || end == null) { return false; }

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();

        float tentativeGScore = 0;
        bool tentativeIsBetter;

        start.g = 0;
        start.h = DistanceH(start, end);
        start.f = start.h;

        open.Add(start);

        while (open.Count > 0)
        {
            int i = LowestF(open);
            Node currentNode = open[i];

            if (currentNode.GetObjID() == endObj)
            {
                ReconstructPath(start, end);
                return true;
            }
            open.RemoveAt(i);
            closed.Add(currentNode);

            Node neighbourNode;
            foreach (Edge e in currentNode.edgeList)
            {
                neighbourNode = e.endNode;

                if (closed.IndexOf(neighbourNode) > -1) { continue; }

                tentativeGScore = currentNode.g + DistanceH(currentNode, neighbourNode);
                if (open.IndexOf(neighbourNode) == -1)
                {
                    open.Add(neighbourNode);
                    tentativeIsBetter = true;
                }
                else if (tentativeGScore < neighbourNode.g) { tentativeIsBetter = true; }
                else { tentativeIsBetter = false; }

                if (tentativeIsBetter)
                {
                    neighbourNode.previous = currentNode;
                    neighbourNode.g = tentativeGScore;
                    neighbourNode.h = DistanceH(currentNode, end);
                    neighbourNode.f = neighbourNode.g + neighbourNode.h;
                }
            }
        }
        return false;
    }

    public void ReconstructPath(Node startNode, Node endNode)
    {
        pathList.Clear();
        pathList.Add(endNode);

        var previousNode = endNode.previous;
        while (previousNode != startNode && previousNode != null)
        {
            pathList.Insert(0, previousNode);
            previousNode = previousNode.previous;
        }
        pathList.Insert(0, startNode);
    }

    private float DistanceH(Node a, Node b)
    {
        return (Vector3.SqrMagnitude(a.GetObjID().transform.position - b.GetObjID().transform.position));
    }

    private int LowestF(List<Node> nodes)
    {
        int count = 0;
        int iteratorCount = 0;

        float lowestF = nodes[0].f;

        for (int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].f < lowestF) { lowestF = nodes[i].f; iteratorCount = count; }

            count++;
        }
        return iteratorCount;
    }
}
