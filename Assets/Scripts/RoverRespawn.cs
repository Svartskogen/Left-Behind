using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player death and respawn.
/// </summary>
public class RoverRespawn : MonoBehaviour
{
    public static Vector3 respawnLocation;
    public static RoverRespawn instance;

    [SerializeField] GameObject explosionDirtFX;
    [SerializeField] ScreenFade screenFade;

    RoverMovement movement;
    void Awake()
    {
        movement = GetComponent<RoverMovement>();
        respawnLocation = transform.position;     //by default, the starting player position is the respawn position
        instance = this;
    }
    //Teleports and enables the rover's movement.
    void Respawn()
    {
        transform.position = respawnLocation;
        movement.enabled = true;
    }
    /// <summary>
    /// Used from the static instance to kill the player after a delay.
    /// </summary>
    public void RespawnWithDelay()
    {
        Debug.Log("Respawn with delay start");
        movement.enabled = false;
        Instantiate(explosionDirtFX, transform.position, Quaternion.identity).SetActive(true);
        screenFade.BlinkGraphic();
        Invoke(nameof(Respawn), 0.5f);
    }
    /// <summary>
    /// Static method for cleaner code when requesting a respawn from other script.
    /// </summary>
    public static void RespawnRover()
    {
        instance.RespawnWithDelay();
    }
}
