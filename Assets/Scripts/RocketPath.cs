using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script based animation for the Rocket ascent path
/// </summary>
public class RocketPath : MonoBehaviour
{
    [HideInInspector] public bool ignite = false;

    float verticalSpeed = 10;
    float windupVerticalSpeed = 0;
    float gravityTurnSpeed = 2;
    // Update is called once per frame
    void Update()
    {
        if (ignite)
        {
            windupVerticalSpeed += Time.deltaTime * 2;
            windupVerticalSpeed = Mathf.Clamp(windupVerticalSpeed, 0, verticalSpeed);
            transform.Translate(transform.up * windupVerticalSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(Time.deltaTime * gravityTurnSpeed, 0, 0));
        }
    }
}
