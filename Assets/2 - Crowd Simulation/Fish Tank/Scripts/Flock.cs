using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;
    GameObject[] fishNeighbours;

    void Start()
    {
        speed = Random.Range(FlockManager.instance.fishMinSpeed, FlockManager.instance.fishMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyFlockingRules();
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void ApplyFlockingRules()
    {
        fishNeighbours = FlockManager.instance.fishArray;

        Vector3 vCenter = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        float groupSize = 0;

        foreach (GameObject fish in fishNeighbours)
        {
            if (fish == this.gameObject) continue;

            nDistance = Vector3.Distance(fish.transform.position, transform.position);
            if (nDistance < FlockManager.instance.neighbourDistance)
            {
                vCenter += fish.transform.position;
                groupSize++;

                if (nDistance < 1.0f)
                {
                    vAvoid += transform.position - fish.transform.position;
                }

                Flock anotherFish = fish.GetComponent<Flock>();
                gSpeed += anotherFish.speed;
            }
        }

        if (groupSize > 0)
        {
            vCenter /= groupSize;
            speed = gSpeed / groupSize;

            Vector3 direction = (vCenter + vAvoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    FlockManager.instance.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
