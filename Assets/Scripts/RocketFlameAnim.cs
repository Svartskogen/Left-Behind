using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlameAnim : MonoBehaviour
{
    MeshRenderer meshRenderer;
    bool ignite;

    Vector3 scaleCalc;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        ignite = false;
        scaleCalc = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (ignite)
        {
            scaleCalc.y = Mathf.PingPong(Time.time * 2f, 0.5f) + 0.3f;
            transform.localScale = scaleCalc;
        }
    }
    [ContextMenu("Ignite")]
    public void Ignite()
    {
        ignite = true;
        meshRenderer.enabled = true;
    }
}
