using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] Transform turretTrans;
    [SerializeField] Transform gunTrans;
    [SerializeField] GameObject shellObj;

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.T)) { turretTrans.RotateAround(turretTrans.position, turretTrans.right, -2f); }
        else if (Input.GetKey(KeyCode.G)) { turretTrans.RotateAround(turretTrans.position, turretTrans.right, 2f); }
        else if (Input.GetKeyDown(KeyCode.B)) { Instantiate(shellObj, gunTrans.position, gunTrans.rotation); }
    }
}
