using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 4f;
    public float trueVisionRange = 1;
    public Transform axis;
    public MeshRenderer displayRenderer;
    public LayerMask everythingLayer;

    public Material onMat;
    public Material offMat;

    public GameObject muzzleFlashFX;

    Transform player;
    RoverLight roverLight;

    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        roverLight = player.GetComponentInChildren<RoverLight>();
    }

    // Update is called once per frame
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
