using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchievmentManager : MonoBehaviour
{
    public GameObject LockedUI1;
    public GameObject LockedUI2;
    public GameObject LockedUI3;
    public GameObject LockedUI4;
    public GameObject LockedUI5;
    public GameObject LockedUI6;
    public GameObject LockedUI7;
    public GameObject LockedUI8;
    public GameObject LockedUI9;
    public GameObject LockedUI10;
    public GameObject LockedUI11;
    public GameObject LockedUI12;

    public GameObject AchievUI1;
    public GameObject AchievUI2;
    public GameObject AchievUI3;
    public GameObject AchievUI4;
    public GameObject AchievUI5;
    public GameObject AchievUI6;
    public GameObject AchievUI7;
    public GameObject AchievUI8;
    public GameObject AchievUI9;
    public GameObject AchievUI10;
    public GameObject AchievUI11;
    public GameObject AchievUI12;

    public static int one = 0;
    public static int two = 0;
    public static int three = 0;
    public static int four = 0;
    public static int five = 0;
    public static int six = 0;
    public static int seven = 0;
    public static int eight = 0;
    public static int nine = 0;
    public static int ten = 0;
    public static int eleven = 0;
    public static int twelve = 0;

    public void Start()
    {
        one = PlayerPrefs.GetInt("OneAch");
        two = PlayerPrefs.GetInt("TwoAch");
        three = PlayerPrefs.GetInt("ThreeAch");
        four = PlayerPrefs.GetInt("FourAch");
        five = PlayerPrefs.GetInt("FiveAch");
        six = PlayerPrefs.GetInt("SixAch");
        seven = PlayerPrefs.GetInt("SevenAch");
        eight = PlayerPrefs.GetInt("EightAch");
        nine = PlayerPrefs.GetInt("NineAch");
        ten = PlayerPrefs.GetInt("TenAch");
        eleven = PlayerPrefs.GetInt("ElevAch");
        twelve = PlayerPrefs.GetInt("TwelAch");
    }

    public void Update()
    {
        if(one == 1)
        {
            LockedUI1.SetActive(false);
            AchievUI1.SetActive(true);
        }

        if(two == 1)
        {
            LockedUI2.SetActive(false);
            AchievUI2.SetActive(true);
        }

        if(three == 1)
        {
            LockedUI3.SetActive(false);
            AchievUI3.SetActive(true);
        }

        if(four == 1)
        {
            LockedUI4.SetActive(false);
            AchievUI4.SetActive(true);
        }

        if(five == 1)
        {
            LockedUI5.SetActive(false);
            AchievUI5.SetActive(true);
        }

        if(six == 1)
        {
            LockedUI6.SetActive(false);
            AchievUI6.SetActive(true);
        }

        if(seven == 1)
        {
            LockedUI7.SetActive(false);
            AchievUI7.SetActive(true);
        }

        if(eight == 1)
        {
            LockedUI8.SetActive(false);
            AchievUI8.SetActive(true);
        }

        if(nine == 1)
        {
            LockedUI9.SetActive(false);
            AchievUI9.SetActive(true);
        }

        if(ten == 1)
        {
            LockedUI10.SetActive(false);
            AchievUI10.SetActive(true);
        }

        if(eleven == 1)
        {
            LockedUI11.SetActive(false);
            AchievUI11.SetActive(true);
        }

        if(twelve == 1)
        {
            LockedUI12.SetActive(false);
            AchievUI12.SetActive(true);
        }
    }
}
