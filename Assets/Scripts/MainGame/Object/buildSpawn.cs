using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSpawn : MonoBehaviour
{
    public GameObject[] buildObj;

    void Start()
    {
        var a = Random.Range(0,6); 
        Instantiate(buildObj[a], transform.position, Quaternion.identity);
    }
}
