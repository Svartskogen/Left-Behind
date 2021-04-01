using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 10f;

    Rigidbody rigidbody;
    Vector3 velocityHolder;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocityHolder = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocityHolder = transform.forward * Input.GetAxis("Vertical") * speed;
        rigidbody.velocity = velocityHolder;
        float reverseMod = 1;
        if (Input.GetAxis("Vertical") < 0)
        {
            reverseMod = -1;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * reverseMod, 0);
    }
}
