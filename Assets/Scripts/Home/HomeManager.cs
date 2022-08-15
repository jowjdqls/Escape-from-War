using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public static float HomeTime;

    public GameObject EscUI;

    public void Start()
    {
        HomeTime = 0;
    }

    public void Update()
    {
        HomeTime += Time.deltaTime;

        if(HomeTime >= 30)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void Xhome()
    {
        EscUI.SetActive(false);
    }

    public void EscOn()
    {
        EscUI.SetActive(true);
    }

    public void escMenuhome()
    {
        SceneManager.LoadScene("intScene");
    }

    public void escRePlayhome()
    {
        SceneManager.LoadScene("MainGame");
        Timer.currenttime = 0;
        PlayerPrefs.SetFloat("Time", Timer.currenttime);
        PlayerPrefs.Save();
    }

    public void escQuithome()
    {
        Application.Quit();
    }

}
