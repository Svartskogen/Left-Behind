using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLowFov : MonoBehaviour
{
    public Transform axis;
    public GameObject laser1;
    public GameObject laser2;
    public float rotationSpeed;
    public MeshRenderer displayRenderer;
    public LayerMask everythingLayer;

    public Material onMat;
    public Material offMat;
    
    public GameObject muzzleFlashFX;

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
