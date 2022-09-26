using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlayerSpawn : MonoBehaviour
{
    public GameObject HomePlayer;

    void Start()
    {
        GameObject homeplayer = Instantiate(HomePlayer);
        homeplayer.transform.position = transform.position;
    }
}
