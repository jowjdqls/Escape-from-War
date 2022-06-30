using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float maxSpeed;
    public GameManager gameManager;
    public GameObject character;

    bool onStay = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

        if(onStay && Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.Ontext();
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * -1)
            rigid.velocity = new Vector2(maxSpeed * -1, rigid.velocity.y);
    }

    public void Move()
    {
        if(Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = (Input.GetAxisRaw("Horizontal") == -1);
        }

        if(Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if(Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "End")
        {
            gameManager.NextStage();
        }
        if(other.gameObject.tag == "EnterStation")
        {
            onStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "EnterStation")
        {
            onStay = false;
        }
    }

    public void respown()
    {
        rigid.velocity = Vector2.zero;
        spriteRenderer.flipY = false;
        transform.position = new Vector3(-5, -2.8f, 0);
    }

    public void Station()
    {
        character.SetActive(false);
    }

    public void Oncharacter()
    {
        character.SetActive(true);
    }
}
