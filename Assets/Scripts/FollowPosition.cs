using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the current gameobject follow its target's position, but keeps its rotation and scale.
/// Used by the Dust storm effect.
/// </summary>
public class FollowPosition : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    
    void Start()
    {
        offset = target.position + transform.position;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
