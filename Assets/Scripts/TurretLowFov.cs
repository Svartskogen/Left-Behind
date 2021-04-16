using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Alternate version of <see cref="Turret"/>, ignores player light but only sees in a straight line
/// </summary>
public class TurretLowFov : MonoBehaviour
{
    [SerializeField] Transform axis;               //Turret rotation axis
    [SerializeField] GameObject laser1;            //lasers gameObjects
    [SerializeField] GameObject laser2;
    [SerializeField] float rotationSpeed;          //Turret rotation speed
    [SerializeField] MeshRenderer displayRenderer; //Turret HDR display
    [SerializeField] LayerMask everythingLayer;    //Turret shoot colision layer, everything by default

    [SerializeField] Material onMat;               //Material used for the display when the turret shoots
    [SerializeField] Material offMat;              //Material used for the display when the turret is looking for the target

    [SerializeField] GameObject muzzleFlashFX;     //Turret muzzle shoot effect

    Transform player;

    const float RANGE = 5.5f;
    bool shoot;
    void Start()
    {
        shoot = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (shoot)
        {
            axis.LookAt(player.transform);
        }
        else
        {
            axis.Rotate(new Vector3(0, Time.deltaTime * rotationSpeed, 0));
        }
        RaycastHit hit;
        if (Physics.Raycast(axis.position + axis.forward - new Vector3(0,0.2f,0), axis.forward, out hit, RANGE, everythingLayer))
        {
            if (hit.transform.CompareTag("Player"))
            {
                TryShoot();
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
        var pos = laser1.transform.localPosition;
        pos.z = 0;
        Instantiate(muzzleFlashFX, axis.TransformPoint(pos), axis.rotation);
        pos = laser2.transform.localPosition;
        pos.z = 0;
        Instantiate(muzzleFlashFX, axis.TransformPoint(pos), axis.rotation);
        Invoke(nameof(Reload), 1f);
    }
    void Reload()
    {
        shoot = false;
        axis.rotation = Quaternion.Euler(0, axis.rotation.eulerAngles.y, 0);
        displayRenderer.material = offMat;
    }
}
