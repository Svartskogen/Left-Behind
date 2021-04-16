using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiates a random prop from the given props array
/// </summary>
public class RandomEnviromentSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] props;
    
    void Start()
    {
        Instantiate(props[Random.Range(0, props.Length)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
