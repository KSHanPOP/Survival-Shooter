using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTemp : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float accel = speed * Time.deltaTime;
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(x, 0, z) * accel;
    }
}
