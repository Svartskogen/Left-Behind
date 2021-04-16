using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used for collectable rocket parts.
/// </summary>
public class RocketPart : MonoBehaviour
{
    public Type type; 
    bool carring = false; //true if its being carried by the player

    float carrySizeModifier = 0.2f;
    SphereCollider collider;
    private void Start()
    {
        collider = GetComponent<SphereCollider>();
    }
    void Equip(GameObject player)
    {
        carring = true;
        transform.parent = player.transform;
        transform.localPosition = new Vector3(0, 0.068f, -0.254f);
        transform.localScale = Vector3.one * carrySizeModifier;
        transform.localRotation = Quaternion.identity;
        collider.radius = collider.radius / carrySizeModifier; 
    }
    private void OnTriggerEnter(Collider other)
    {
        //If the item is in the world and his trigger touches the player, the RocketPart equips itself to the player
        if (!carring && other.gameObject.CompareTag("Player"))
        {
            Equip(other.gameObject);
            return;
        }
        //If the RocketPart is being carried by the player and touches an Interactable object, checks if its the RocketPlatforms and adds itself to it
        if(carring && other.gameObject.CompareTag("Interactable"))
        {
            var platform = other.GetComponent<RocketPlatform>();
            if(platform != null)
            {
                platform.AddPart(type);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    public enum Type
    {
        Base, Fuel, Sides, Fins, Top
    }
}
