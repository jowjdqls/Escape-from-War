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

    public static Action AchM;

    public static int one = PlayerPrefs.GetInt("one", 0);
    public int two = PlayerPrefs.GetInt("two", 0);
    public int three = PlayerPrefs.GetInt("three", 0);
    public int four = PlayerPrefs.GetInt("four", 0);
    public int five = PlayerPrefs.GetInt("five", 0);
    public int six = PlayerPrefs.GetInt("six", 0);
    public int seven = PlayerPrefs.GetInt("seven", 0);
    public int eghit = PlayerPrefs.GetInt("eghit", 0);
    public int nine = PlayerPrefs.GetInt("nine", 0);
    public int ten = PlayerPrefs.GetInt("ten", 0);

    private void Awake()
    {
        AchM = () => { OneUp(); };
    }

    public void OneUp()
    {
        if(one == 0)
        {
            one++;
            PlayerPrefs.SetInt("OneAch", one);
            PlayerPrefs.Save();
        }
        else if(one == 1)
        {
            one = 1;
        }
        Debug.Log("aaaaaaaaa");
    }

    public void Update()
    {
        //PlayerPrefs.GetInt("One");

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

        if(eghit == 1)
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
    }
}
