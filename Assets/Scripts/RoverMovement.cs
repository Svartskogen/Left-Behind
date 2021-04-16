using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple physics based rover movement.
/// Features inverse controls when going reverse.
/// </summary>
public class RoverMovement : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 10f;

    Rigidbody rigidbody;
    Vector3 velocityHolder;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocityHolder = Vector3.zero;
    }

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
