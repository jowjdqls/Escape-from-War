using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryCarMove : MonoBehaviour
{
    public float Speed = 3;


    private void Update() 
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
