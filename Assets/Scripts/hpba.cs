using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpba : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;  
        hugrybar.value = (float) curhu / (float) maxhu;
        waterbar.value = (float) curWa / (float) maxWa;

    }

    // Update is called once per frame
    void Update()
    {
        HpManager();
        Die();
        HandleHp();
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
