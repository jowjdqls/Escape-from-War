using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public static float HomeTime;
    public static bool HomeStopGame;

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
        StartHomeGame();
    }

    public void EscOn()
    {
        EscUI.SetActive(true);
        StopHomeGame();
    }

    public void escMenuhome()
    {
        SceneManager.LoadScene("intScene");
        StartHomeGame();
    }

    public void escRePlayhome()
    {
        SceneManager.LoadScene("MainGame");
        Timer.currenttime = 0;
        StartHomeGame();
        PlayerPrefs.SetFloat("Time", Timer.currenttime);
        PlayerPrefs.Save();
    }

    public void escQuithome()
    {
        Application.Quit();
        StartHomeGame();
    }

    public void StopHomeGame()
    {
        Time.timeScale = 0;
        HomeStopGame = true;
        return;
    }

    public void StartHomeGame()
    {
        Time.timeScale = 1;
        HomeStopGame =false;
        return;
    }
}
