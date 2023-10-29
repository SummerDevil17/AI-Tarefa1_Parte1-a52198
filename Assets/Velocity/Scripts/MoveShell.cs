using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, Time.deltaTime * (speed / 2), Time.deltaTime * speed);
    }
}
