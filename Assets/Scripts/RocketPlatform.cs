using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlatform : MonoBehaviour, IInteractable
{
    public MeshRenderer display;
    public Material onMaterial;
    public Material offMaterial;

    [SerializeField] MeshRenderer rocketBase;
    [SerializeField] MeshRenderer rocketFuel;
    [SerializeField] MeshRenderer rocketSides;
    [SerializeField] MeshRenderer rocketFins;
    [SerializeField] MeshRenderer rocketTop;
    
    void Awake()
    {
        rocketBase.enabled = false;
        rocketFuel.enabled = false;
        rocketSides.enabled = false;
        rocketFins.enabled = false;
        rocketTop.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRocketComplete())
        {
            display.material = onMaterial;
        }
        else
        {
            display.material = offMaterial;
        }
    }
    bool IsRocketComplete()
    {
        return (rocketBase.enabled && rocketFuel.enabled && rocketSides.enabled && rocketFins.enabled && rocketTop.enabled);
    }
    public void Interact()
    {
        if (IsRocketComplete())
        {
            //END GAME
        }
    }
    public void AddPart(RocketPart.Type partType)
    {
        switch (partType)
        {
            case RocketPart.Type.Base:
                rocketBase.enabled = true;
                return;
            case RocketPart.Type.Fuel:
                rocketFuel.enabled = true;
                return;
            case RocketPart.Type.Sides:
                rocketSides.enabled = true;
                return;
            case RocketPart.Type.Fins:
                rocketFins.enabled = true;
                return;
            case RocketPart.Type.Top:
                rocketTop.enabled = true;
                return;
        }
    }
}
