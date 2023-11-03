using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager instance;

    [SerializeField] GameObject[] fishPrefabs;
    [SerializeField] int numberOfFish = 20;
    public GameObject[] fishArray;
    [SerializeField] Vector3 swimLimits = new Vector3(5, 5, 5);
    public Vector3 goalPosition;

    [Header("Fish Settings")]
    [Range(0f, 5f)]
    public float fishMinSpeed = 0.2f;
    [Range(0f, 5f)]
    public float fishMaxSpeed = 1.2f;

    [Range(1f, 10f)]
    public float neighbourDistance = 5f;
    [Range(1f, 5f)]
    public float rotationSpeed = 2f;

    void Start()
    {
        fishArray = new GameObject[numberOfFish];

        for (int i = 0; i < numberOfFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.y, swimLimits.y),
                                                                Random.Range(-swimLimits.z, swimLimits.z));

            fishArray[i] = Instantiate(fishPrefabs[Random.Range(0, fishPrefabs.Length)], pos, Quaternion.identity);
        }
        instance = this;
        goalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            goalPosition = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.y, swimLimits.y),
                                                                Random.Range(-swimLimits.z, swimLimits.z));
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(goalPosition, 0.2f);
    }
}
