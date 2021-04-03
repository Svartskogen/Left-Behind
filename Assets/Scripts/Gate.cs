using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public ActivableGate[] keys;
    public bool open = false;
    public bool inverse = false;

    Vector3 closePos;
    Vector3 openPos;
    float speed = 0.2f;
    private void Start()
    {
        closePos = transform.position;
        openPos = transform.position;
        openPos.y -= 1;
    }

    private void Update()
    {
        if (open)
        {
            if(transform.position != openPos)
            {
                var dir = openPos - transform.position;
                dir = dir.normalized;
                transform.position = Vector3.MoveTowards(transform.position, openPos, Time.deltaTime * speed);
            }
        }
        else
        {
            if (transform.position != closePos)
            {
                var dir = closePos - transform.position;
                dir = dir.normalized;
                transform.position = Vector3.MoveTowards(transform.position, closePos, Time.deltaTime * speed);
            }
        }
    }

    void FixedUpdate()
    {
        open = CheckKeys();
    }
    bool CheckKeys()
    {
        if (inverse)
        {
            foreach (ActivableGate key in keys)
            {
                if (key.State)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            foreach (ActivableGate key in keys)
            {
                if (!key.State)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
