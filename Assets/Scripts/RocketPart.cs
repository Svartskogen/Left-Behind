using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//al acercarse al jugador, se le equipa y se le asigna como padre. se activa modo carry
//al estar en modo carry, si se acerca a una Rocket Platform se agrega ese tipo de parte
public class RocketPart : MonoBehaviour
{
    public Type type;
    bool carring = false; //true si esta parte la esta llevando el jugador

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
        if (!carring && other.gameObject.CompareTag("Player"))
        {
            Equip(other.gameObject);
            return;
        }
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
        //if !carring and player: equip
        //if carring and plaform: add
    }
    public enum Type
    {
        Base, Fuel, Sides, Fins, Top
    }
}
