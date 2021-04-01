using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnviromentSpawner : MonoBehaviour
{
    public GameObject[] props;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(props[Random.Range(0, props.Length)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
