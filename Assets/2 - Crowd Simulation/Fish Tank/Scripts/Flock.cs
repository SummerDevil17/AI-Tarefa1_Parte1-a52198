using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range(FlockManager.instance.fishMinSpeed, FlockManager.instance.fishMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
