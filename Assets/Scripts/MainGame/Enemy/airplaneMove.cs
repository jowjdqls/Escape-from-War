using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneMove : MonoBehaviour
{
    public float speed;

    void Start()
    {
       
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
         
    }
}
