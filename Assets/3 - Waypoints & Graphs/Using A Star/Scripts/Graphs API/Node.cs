using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Edge> edgeList = new List<Edge>();
    public Node path = null;
    GameObject objID;

    public float f, g, h;
    public Node previous;

    /// <summary>
    /// Creates a Node from a GameObject.
    /// </summary>
    /// <param name="prefab"></param> <summary>
    /// 
    /// </summary>
    /// <param name="prefab"></param>
    public Node(GameObject prefab)
    {
        objID = prefab;
        path = null;
    }

    public GameObject GetObjID() { return objID; }
}
