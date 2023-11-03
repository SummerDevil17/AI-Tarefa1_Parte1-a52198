using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager instance;

    [SerializeField] GameObject[] fishPrefabs;
    [SerializeField] int numberOfFish = 20;
    [SerializeField] GameObject[] fishArray;
    [SerializeField] Vector3 swimLimits = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0f, 5f)]
    public float fishMinSpeed = 1f;
    [Range(0f, 5f)]
    public float fishMaxSpeed = 2f;


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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
