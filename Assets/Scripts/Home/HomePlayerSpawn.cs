using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlayerSpawn : MonoBehaviour
{
    public GameObject HomePlayer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject homeplayer = Instantiate(HomePlayer);
        homeplayer.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
