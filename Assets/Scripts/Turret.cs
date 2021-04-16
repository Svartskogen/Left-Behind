using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple turret that shoots the player based on range and if he has lights on
/// </summary>
public class Turret : MonoBehaviour
{
    [SerializeField] float range = 4f;            //Range at which the turret tries to shoot if the player has lights on
    [SerializeField] float trueVisionRange = 1;   //Range at which the turret tries to shoot regardless of the player lights
    [SerializeField] Transform axis;              //Turret rotation axis
    [SerializeField] MeshRenderer displayRenderer;//Turret HDR display
    [SerializeField] LayerMask everythingLayer;   //Turret shoot colision layer, everything by default

    [SerializeField] Material onMat;              //Material used for the display when the turret shoots
    [SerializeField] Material offMat;             //Material used for the display when the turret is looking for the target

    [SerializeField] GameObject muzzleFlashFX;    //Turret muzzle shoot effect

    Transform player;
    RoverLight roverLight;

    bool shoot;

    void Start()
    {
        shoot = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        roverLight = player.GetComponentInChildren<RoverLight>();
    }

    void Update()
    {
        axis.LookAt(player.transform);

        var dist = Vector3.Distance(transform.position, player.position);
        if (roverLight.light.enabled && dist < range)
        {
            RaycastHit hit;
            if (Physics.Raycast(axis.position + axis.forward, axis.forward, out hit, range, everythingLayer))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    TryShoot();
                }
            }
            
        }
        else if(dist < trueVisionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(axis.position + axis.forward, axis.forward, out hit, trueVisionRange, everythingLayer))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    TryShoot();
                }
            }
        }
    }
    void TryShoot()
    {
        if (!shoot)
        {
            shoot = true;
            displayRenderer.material = onMat;
            Invoke(nameof(Shoot), 0.5f);
        }
    }
    void Shoot()
    {
        RoverRespawn.RespawnRover();
        Instantiate(muzzleFlashFX, axis.position, axis.rotation);
        Invoke(nameof(Reload), 1f);
    }
    void Reload()
    {
        shoot = false;
        displayRenderer.material = offMat;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trueVisionRange);
    }
}
