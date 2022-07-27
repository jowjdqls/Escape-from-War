using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public PlayerMove Player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "misile" && Player.boxcount == 0)
        {
            Player.Damagemisile();
            Destroy(other.gameObject);
        }
    }
}
