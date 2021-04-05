using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//al acercarse al jugador, se le equipa y se le asigna como padre. se activa modo carry
//al estar en modo carry, si se acerca a una Rocket Platform se agrega ese tipo de parte
public class RocketPart : MonoBehaviour
{
    public Type type;
    bool carring = false; //true si esta parte la esta llevando el jugador

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if !carring and player: equip
        //if carring and plaform: add
    }
    public enum Type
    {
        Base, Fuel, Sides, Fins, Top
    }
}
