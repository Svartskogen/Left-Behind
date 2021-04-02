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

    Transform player;
    RoverLight roverLight;

    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Player"))
                {
                    TryShoot();
                }
            }
            
        }
        if(dist < trueVisionRange)
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
    public void TryShoot()
    {
        displayRenderer.material = onMat;
        Invoke(nameof(Shoot), 0.5f);
    }
    public void Shoot()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trueVisionRange);
    }
}
