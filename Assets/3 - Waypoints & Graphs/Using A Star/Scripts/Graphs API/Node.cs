using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Edge> edgeList = new List<Edge>();
    public Node path = null;
    GameObject objID;
    public float xPos, yPos, zPos;

    public float f, g, h;
    public Node cameFrom;

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
        xPos = prefab.transform.position.x;
        yPos = prefab.transform.position.y;
        zPos = prefab.transform.position.z;

        path = null;
    }

    public GameObject GetObjID() { return objID; }
}
