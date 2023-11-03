using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;
    GameObject[] fishNeighbours;
    bool turning = false;

    void Start()
    {
        speed = Random.Range(FlockManager.instance.fishMinSpeed, FlockManager.instance.fishMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Bounds swimBounds = new Bounds(FlockManager.instance.transform.position,
                                        FlockManager.instance.swimLimits * 2);
        if (!swimBounds.Contains(transform.position)) { turning = true; }
        else { turning = false; }

        if (turning)
        {
            Vector3 direction = FlockManager.instance.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                                                FlockManager.instance.rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 100) < 20)
            {
                speed = Random.Range(FlockManager.instance.fishMinSpeed, FlockManager.instance.fishMaxSpeed);
            }

            if (Random.Range(0, 100) < 30)
            {
                ApplyFlockingRules();
            }
        }
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
            vCenter = vCenter / groupSize + (FlockManager.instance.goalPosition - transform.position);
            speed = gSpeed / groupSize;
            if (speed > FlockManager.instance.fishMaxSpeed) { speed = FlockManager.instance.fishMaxSpeed; }

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
