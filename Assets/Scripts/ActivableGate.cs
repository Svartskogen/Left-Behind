using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableGate : MonoBehaviour, IInteractable
{
    public bool State { get; set; }
    [SerializeField] Material offMaterial;
    [SerializeField] Material onMaterial;
    [SerializeField] bool initialState = false;
    [SerializeField] bool isCheckpoint = false;

    MeshRenderer displayRenderer;
    private void Awake()
    {
        displayRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        SetStateTo(initialState);
    }

    public void SetStateTo(bool state)
    {
        State = state;
        if (state)
        {
            displayRenderer.material = onMaterial;
            if (isCheckpoint)
            {
                RoverRespawn.respawnLocation = transform.position + transform.right;
            }
        }
        else
        {
            displayRenderer.material = offMaterial;
        }
    }
    [ContextMenu("SwitchState")]
    public void SwitchState()
    {
        SetStateTo(!State);
    }
    public void Interact()
    {
        SwitchState();
    }
}
