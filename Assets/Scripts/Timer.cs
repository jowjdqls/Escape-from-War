using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currenttime;
    public static float besttime;

    public Text Timertext;
    public Text BesttimeText;

    // Start is called before the first frame update
    void Start()
    {
        currenttime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currenttime += Time.deltaTime;
        Timertext.text = "시간 : " + Mathf.Round(currenttime);
    }
}
