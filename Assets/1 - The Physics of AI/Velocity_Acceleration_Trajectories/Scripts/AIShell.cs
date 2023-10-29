using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour
{
    public GameObject explosion;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.forward = rb.velocity;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank" || col.gameObject.tag == "Ground")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
