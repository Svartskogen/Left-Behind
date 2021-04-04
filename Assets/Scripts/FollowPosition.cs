using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform follow;
    Vector3 offset;
    
    void Start()
    {
        offset = follow.position + transform.position;
    }

    void LateUpdate()
    {
        transform.position = follow.position + offset;
    }
}
