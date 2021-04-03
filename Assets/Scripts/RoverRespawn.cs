using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverRespawn : MonoBehaviour
{
    public static Vector3 respawnLocation;
    public static RoverRespawn instance;

    RoverMovement movement;
    void Awake()
    {
        movement = GetComponent<RoverMovement>();
        respawnLocation = transform.position;
        instance = this;
    }
    void Respawn() //reaparece y reinicia los scripts.
    {
        transform.position = respawnLocation;
        movement.enabled = true;
    }
    public void RespawnWithDelay() //usado desde la instancia para matar al jugador con un delay.
    {
        movement.enabled = false;
        Invoke(nameof(Respawn), 0.5f);
    }
    public static void RespawnRover() //metodo estatico llamado desde torretas y demas.
    {
        instance.RespawnWithDelay();
    }
}
