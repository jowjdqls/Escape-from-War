using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public Slider hpbar;
    public Slider hugrybar;
    public Slider waterbar;

    public float maxHp = 100;
    public float curHp = 100;
    public float maxhu = 100;
    public float curhu = 100;
    public float maxWa = 100;
    public float curWa = 100;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float maxSpeed;
    public GameManager gameManager;
    public GameObject character;

    bool onStay = false;
    bool onCar = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;  
        hugrybar.value = (float) curhu / (float) maxhu;
        waterbar.value = (float) curWa / (float) maxWa;
    }

    void Update()
    {
        Move();

        if(onStay && Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.Ontext();
        }
        if(onCar && Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.IntCar();
        }

        HpManager();
        Die();
        HandleHp();
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
        if(other.gameObject.tag == "Car")
        {
            onCar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "EnterStation")
        {
            onStay = false;
        }
        if(other.gameObject.tag == "Car")
        {
            onCar = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "misile")
        {
            Damagemisile();
            Destroy(other.gameObject);
        }    
    }

    public void respown()
    {
        rigid.velocity = Vector2.zero;
        spriteRenderer.flipY = false;
        transform.position = new Vector3(-5, -2.8f, 0);
    }

    public void offCharacter()
    {
        character.SetActive(false);
    }

    public void Oncharacter()
    {
        character.SetActive(true);
    }

    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
        hugrybar.value = (float)curhu / (float)maxhu;
        waterbar.value = (float) curWa / (float) maxWa;
    }

    public void Die()
    {
        if(curHp <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void Damagemisile()
    {
        curHp -= 80f;
    }
    
    public void HpManager()
    {
        if(curhu >= 75)
        {
            curhu -= 0.002f;
        }
        else if(curhu >= 50)
        {
            curhu -= 0.005f;
        }
        else if(curhu >= 25)
        {
            curhu -= 0.008f;
        }
        else if(curhu >= 0)
        {
            curhu -= 0.01f;
        }
        
        if(curWa >= 75)
        {
            curWa -= 0.002f;
        }
        else if(curWa >= 50)
        {
            curWa -= 0.005f;
        }
        else if(curWa >= 25)
        {
            curWa -= 0.008f;
        }
        else if(curWa >= 0)
        {
            curWa -= 0.01f;
        }

        if(50 >= curhu && curWa >= 25)
        {
            curHp -= 0.002f;
        }
        else if(25 >= curhu && curWa > 0)
        {
            curHp -= 0.005f;
        }
        else if(curhu <= 0 && curWa <=0)
        {
            curHp -= 0.008f;
        }
    }
}
