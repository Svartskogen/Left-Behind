using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Smooth camera follow script, by default targets the first GameObject tagged Player, but can switch to different using <see cref="CameraFollow.target"/>
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public static GameObject target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
