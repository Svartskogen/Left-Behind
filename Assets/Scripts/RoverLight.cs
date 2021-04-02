using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverLight : MonoBehaviour
{
    public KeyCode lightKey;
    public KeyCode altLightKey;

    public Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(lightKey) || Input.GetKeyDown(altLightKey))
        {
            light.enabled = !light.enabled;
        }   
    }
}
