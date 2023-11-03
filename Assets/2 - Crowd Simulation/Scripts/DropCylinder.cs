using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    GameObject[] agents;


    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("Agent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hitInfo))
            {
                Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);

                /*foreach (GameObject agent in agents)
                {
                    agent
                }*/
            }
        }
    }
}
