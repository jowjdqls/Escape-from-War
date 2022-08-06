using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveHome : MonoBehaviour
{

    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * Speed);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ExistHome")
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}