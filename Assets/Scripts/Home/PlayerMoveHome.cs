using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveHome : MonoBehaviour
{
    public VariableJoystick Joy;
    public int Speed;
    public float htime = 0;

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Timer.currenttime = PlayerPrefs.GetFloat("Time");
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        htime += Time.deltaTime;
        moveCh();
    }

    void FixedUpdate()
    {
        float x = Joy.Horizontal;
        float y = Joy.Vertical;

        if(x != 0 || y != 0)
            anim.SetBool("ismove",true);
        else
            anim.SetBool("ismove", false);

        anim.SetFloat("InputX", x);
        anim.SetFloat("InputY", y);

        transform.Translate(new Vector2(x, y) * Speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ExistHome")
        {
            Timer.currenttime = PlayerPrefs.GetFloat("Time");
            LoddingManager.LoadScene("MainGame");
            transform.Translate(new Vector3(-15, -11, 0));
        }
    }

    public void moveCh()
    {
        if(htime > 30)
        {
            transform.Translate(new Vector3(-15, -11, 0));
        }
    }
}
