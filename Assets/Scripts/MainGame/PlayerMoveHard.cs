using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMoveHard : MonoBehaviour
{
    [SerializeField]
    public Slider hpbar;

    public static float maxHp = 100;
    public static float curHp = 100;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Vector2 moveVec;

    public float maxSpeed;
    public GameManager gameManager;
    public GameObject character;
    public VariableJoystick MJoy;

    public float Gettent = 1;
    public float HealTent = 0;

    public float Attackenemy = 1;

    public float boxcount = 1;

    public float GetHospital = 1;
    public float HospitalP = 1;
    public float HospitalPHeal = 0;

    public static float EnterHome = 0;

    bool onStay = false;
    bool onCar = false;
    bool OnTent = false;
    bool OnHospital = false;
    bool OnBox = false;
    bool Onpharmacy = false;
    bool OnMart = false;

    bool BtuDown = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        maxHp = 100;
        curHp = 100;
        hpbar.value = (float) curHp / (float) maxHp;  
    }

    void Update()
    {
        Move();

        if(onStay && BtuDown)
        {
            gameManager.Ontext();
            gameManager.StopGameTime();
            StopPlayer();
        }
        if(onCar && BtuDown && GameManager.CarKey == 1)
        {
            gameManager.IntCar();
            gameManager.StopGameTime();
            StopPlayer();
        }
        else if(onCar && BtuDown && GameManager.CarKey == 0)
        {
            gameManager.DonotIntCar();
            gameManager.StopGameTime();
            StopPlayer();
        }
        if(OnTent && BtuDown && Gettent == 1)
        {
            gameManager.OnTenttext();
            gameManager.StopGameTime();
            StopPlayer();
        }
        else if(OnTent && BtuDown && Gettent == 0)
        {
            gameManager.OnTentGet();
            gameManager.StopGameTime();
            StopPlayer();
        }
        if(OnHospital && BtuDown && GetHospital == 1)
        {
            gameManager.OnHospitalText();
            gameManager.StopGameTime();
            StopPlayer();
        }
        else if(OnHospital && BtuDown && GetHospital == 0 && HospitalP == 1)
        {
            gameManager.OnHospitalEnt();
            gameManager.StopGameTime();
            StopPlayer();
        }
        else if(OnHospital && BtuDown && GetHospital == 0 && HospitalP == 0)
        {
            gameManager.OnHospitalNoEnt();
            gameManager.StopGameTime();
            StopPlayer();
        }

        if(OnBox && BtuDown)
        {
            gameManager.OnBoxText();
            gameManager.StopGameTime();
            StopPlayer();
        }

        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        if(Onpharmacy && BtuDown && GameManager.WalletP == 1)
        {
            gameManager.IntPharmacy();
            gameManager.StopGameTime();
            StopPlayer();
        }
        else if(Onpharmacy && BtuDown && GameManager.WalletP == 0)
        {
            gameManager.NomoneyPharmacy();
            gameManager.StopGameTime();
            StopPlayer();
        }

        if(OnMart && BtuDown && GameManager.WalletP == 1)
        {
            gameManager.IntMart();
            gameManager.StopGameTime();
            StopPlayer();
        }
        else if(OnMart && BtuDown && GameManager.WalletP == 0)
        {
            gameManager.NomoneyPharmacy();
            gameManager.StopGameTime();
            StopPlayer();
        }


        DonotAttack();
        Die();
        HandleHp();
        MaXStat();
        HealTentPoint();
        HealTentUp();
        HealHospitalP();
        HealHospitalPUP();
    }

    void FixedUpdate()
    {

        float MainX = MJoy.Horizontal;

        moveVec = new Vector2(MainX, 0) * maxSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        if(moveVec != Vector2.right)
            spriteRenderer.flipX = MJoy.Horizontal < 0;

        if(MainX != 0)
            anim.SetBool("ismove", true);
        else
            anim.SetBool("ismove", false);

        anim.SetFloat("InputX", MainX);
        
    }

    public void stopGame()
    {
        gameManager.StopGameTime();
        StopPlayer();
    }

    public void startGame()
    {
        gameManager.StartGameTime();
        StartPlayer();
    }

    public void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MilitaryCar")
        {
            gameManager.MeetMilitaryCar();
            gameManager.StopGameTime();
            StopPlayer();
        }
        if(other.gameObject.tag == "End")
        {
            gameManager.NextStage();
            gameManager.DestroyClone();
        }
        if(other.gameObject.tag == "EnterStation")
        {
            onStay = true;
        }
        if(other.gameObject.tag == "Car")
        {
            onCar = true;
        }
        if(other.gameObject.tag == "EnterTent")
        {
            OnTent = true;
        }
        if(other.gameObject.tag == "EnterHospital")
        {
            OnHospital = true;
        }
        if(other.gameObject.tag == "Boxes")
        {
            OnBox = true;
        }
        if(other.gameObject.tag == "EnterPharmacy")
        {
            Onpharmacy = true;
        }
        if(other.gameObject.tag == "EnterMart")
        {
            OnMart = true;
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
        if(other.gameObject.tag == "EnterTent")
        {
            OnTent = false;
        }
        if(other.gameObject.tag == "EnterHospital")
        {
            OnHospital = false;
        }
        if(other.gameObject.tag == "Boxes")
        {
            OnBox = false;
        }
        if(other.gameObject.tag == "EnterPharmacy")
        {
            Onpharmacy = false;
        }
        if(other.gameObject.tag == "EnterMart")
        {
            OnMart = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "misile")
        {
            Damagemisile();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy" && Attackenemy == 1)
        {
            DamageEnemy();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "EnterHome" && EnterHome == 0)
        {
            LoddingManager.LoadScene("IntHome");
            EnterHome = 1;
            AchievmentManager.seven = 1;
            PlayerPrefs.SetInt("SevenAch", AchievmentManager.seven);
            PlayerPrefs.Save();
        }
    }

    public void respown()
    {
        rigid.velocity = Vector2.zero;
        spriteRenderer.flipY = false;
        transform.position = new Vector3(-5, -2.8f, 0);
    }

    public void StopPlayer()
    {
        gameObject.GetComponent<PlayerMoveHard>().enabled = false;
    }

    public void StartPlayer()
    {
        gameObject.GetComponent<PlayerMoveHard>().enabled = true;
    }

    public void noPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        maxSpeed = 0;
        Attackenemy -= 1;
    }

    public void yesPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        maxSpeed = 5;
        Attackenemy += 1;
    }

    public void DonotAttack()
    {
        if(Attackenemy == 0)
        {
            Physics2D.IgnoreLayerCollision(10,11);
        }
        else if(Attackenemy == 1)
        {
            Physics2D.IgnoreLayerCollision(10,11, false);
        }
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
    }

    public void Die()
    {
        if(curHp <= 0 && EnterHome == 0)
        {
            SceneManager.LoadScene("DieScene");
            AchievmentManager.five = 1;
            PlayerPrefs.SetInt("FiveAch", AchievmentManager.five);
            PlayerPrefs.Save();
        }
        else if(curHp <= 0 && EnterHome == 1)
        {
            SaveHomePlayer.P_instance.DestroyHomePlayer();
            SaveInvenUI.instance.DestroyUI();
            SceneManager.LoadScene("DieScene");
            AchievmentManager.five = 1;
            PlayerPrefs.SetInt("FiveAch", AchievmentManager.five);
            PlayerPrefs.Save();
        }
    }

    public void Damagemisile()
    {
        curHp -= 90f;
        AchievmentManager.three = 1;
        PlayerPrefs.SetInt("ThreeAch", AchievmentManager.three);
        PlayerPrefs.Save();
    }

    public void DamageEnemy()
    {
        curHp -= 10f;
        AchievmentManager.nine = 1;
        PlayerPrefs.SetInt("NineAch", AchievmentManager.nine);
        PlayerPrefs.Save();
    }

    public void OnPointerDown()
    {
        BtuDown = true;
    }

    public void OnPointerUp()
    {
        BtuDown = false;
    }

    public void MaXStat()
    {
        if(curHp > 100)
        {
            curHp = 100;
        }
    }

    public void HealTentPoint()
    {
        if(HealTent >= 50)
        {
            Gettent = 1;
            HealTent = 0;
        }
    }

    public void HealTentUp()
    {
        if(Gettent == 0)
        {
            HealTent += 0.01f;
        }
    }

    public void HealHospitalP()
    {
        if(HospitalPHeal >= 60)
        {
            HospitalP = 1;
            HospitalPHeal = 0;
        }
    }

    public void HealHospitalPUP()
    {
        if(HospitalP == 0)
        {
            HospitalPHeal += 0.01f;
        }
    }
    
}
