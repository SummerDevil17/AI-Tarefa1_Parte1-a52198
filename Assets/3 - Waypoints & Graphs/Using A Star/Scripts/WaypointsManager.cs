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
    public GameObject[] waypoints;
    public Link[] links;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
