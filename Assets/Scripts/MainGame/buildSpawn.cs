using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSpawn : MonoBehaviour
{
    public GameObject[] buildObj;

    // Start is called before the first frame update
    void Start()
    {
        var a = Random.Range(0,4); 
        Instantiate(buildObj[a], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
