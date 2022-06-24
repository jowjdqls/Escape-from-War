using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            curHp -= 10;
            curhu -= 10;
            curWa -= 10;
            print("aaaaa");
        }
        HandleHp();
    }
    
    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
        hugrybar.value = (float)curhu / (float)maxhu;
        waterbar.value = (float) curWa / (float) maxWa;

    }
}
