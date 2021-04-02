using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverInteraction : MonoBehaviour
{
    public KeyCode interactKey;
    public KeyCode altInteractKey;
    public LayerMask everythingLayer;
    public float interactRange = 10f;
    
    void Update()
    {
        if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(altInteractKey))
        {
            InteractArea();
        }
    }
    public void InteractArea()
    {
        var colliders = Physics.OverlapSphere(transform.position, interactRange, everythingLayer);
        foreach(Collider col in colliders)
        {
            if (col.gameObject.CompareTag("Interactable"))
            {
                col.GetComponent<IInteractable>().Interact();
            }
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
