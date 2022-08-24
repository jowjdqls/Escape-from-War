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

    public GameObject TimeUI1;
    public GameObject TimeUI2;

    public void Start()
    {
        HomeTime = 0;
        TimeUI1.SetActive(false);
        TimeUI2.SetActive(false);
    }

    public void Update()
    {
        HomeTime += Time.deltaTime;

        if(HomeTime >= 30)
        {
            LoddingManager.LoadScene("MainGame");
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
        SaveHomePlayer.P_instance.DestroyHomePlayer();
        SaveInvenUI.instance.DestroyUI();
        SceneManager.LoadScene("intScene");
        Timer.currenttime = 0;
        PlayerPrefs.SetFloat("Time", Timer.currenttime);
        PlayerPrefs.Save();
        StartHomeGame();
    }

    public void escRePlayhome()
    {
        LoddingManager.LoadScene("MainGame");
        //SceneManager.LoadScene("MainGame");
        SaveHomePlayer.P_instance.DestroyHomePlayer();
        SaveInvenUI.instance.DestroyUI();
        PlayerMove.EnterHome = 0;
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
