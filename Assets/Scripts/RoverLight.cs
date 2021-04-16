using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enables toggling on/off the rover light
/// </summary>
public class RoverLight : MonoBehaviour
{
    public KeyCode lightKey;
    public KeyCode altLightKey;

    public Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if(Input.GetKeyDown(lightKey) || Input.GetKeyDown(altLightKey))
        {
            light.enabled = !light.enabled;
        }   
    }
}
