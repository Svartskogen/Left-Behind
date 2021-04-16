using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Activable switch that can be used to open <see cref="Gate"/>s
/// </summary>
public class ActivableGate : MonoBehaviour, IInteractable
{
    public bool State { get; set; }             //The switch's state
    [SerializeField] Material offMaterial;      //Material used for the display when the Switch is set to false
    [SerializeField] Material onMaterial;       //Material used for the display when the Switch is set to true
    [SerializeField] bool initialState = false; //initial switch State, defaults to false
    [SerializeField] bool isCheckpoint = false; //if true, also sets the players respawn position

    MeshRenderer displayRenderer;
    private void Awake()
    {
        displayRenderer = transform.GetChild(0).GetComponent<MeshRenderer>(); //assuming the display object is a child of the switch
        SetStateTo(initialState);
    }

    public void SetStateTo(bool state)
    {
        State = state;
        if (state)
        {
            displayRenderer.material = onMaterial;
            if (isCheckpoint && !initialState)
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
