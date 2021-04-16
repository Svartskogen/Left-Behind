using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script based animation for the rocket exhaust
/// </summary>
public class RocketFlameAnim : MonoBehaviour
{
    MeshRenderer meshRenderer;
    bool ignite;

    Vector3 scaleCalc;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        ignite = false;
        scaleCalc = transform.localScale;
    }

    void Update()
    {
        if (ignite)
        {
            scaleCalc.y = Mathf.PingPong(Time.time * 2f, 0.5f) + 0.3f;
            transform.localScale = scaleCalc;
        }
    }

    /// <summary>
    /// Starts the animation.
    /// </summary>
    [ContextMenu("Ignite")]
    public void Ignite()
    {
        ignite = true;
        meshRenderer.enabled = true;
    }
}
