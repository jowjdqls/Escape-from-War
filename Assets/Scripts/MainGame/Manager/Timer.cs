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

    void Start()
    {
        currenttime = 0;
    }

    void Update()
    {
        currenttime += Time.deltaTime;
        Timertext.text = "시간 : " + Mathf.Round(currenttime);
    }
}
