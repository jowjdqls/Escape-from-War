using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public GameObject UIImagefirst;
    public GameObject UIImageSecond;
    public GameObject UIImagethird;
    public GameObject UIcloseBtu;
    public GameObject UInextBtu;
    public GameObject UInextBtu2;
    public GameObject UIbackBtu;
    public GameObject UIbackBtu2;

    public void Start()
    {
        UIImagefirst.SetActive(false);
        UIImageSecond.SetActive(false);
        UInextBtu.SetActive(false);
        UIbackBtu.SetActive(false);
        UIcloseBtu.SetActive(false);
        IntroManager.FirstPlay = PlayerPrefs.GetInt("FirstP");
    }

    public void help()
    {
        UIImagefirst.SetActive(true);
        UInextBtu.SetActive(true);
        UIcloseBtu.SetActive(true);
    }

    public void closehelp()
    {
        UIImagefirst.SetActive(false);
        UIImageSecond.SetActive(false);
        UIImagethird.SetActive(false);
        UInextBtu.SetActive(false);
        UInextBtu2.SetActive(false);
        UIbackBtu.SetActive(false);
        UIbackBtu2.SetActive(false);
        UIcloseBtu.SetActive(false);
    }

    public void nextone()
    {
        UIImageSecond.SetActive(true);
        UInextBtu2.SetActive(true);
        UIbackBtu.SetActive(true);
        UIImagefirst.SetActive(false);
        UInextBtu.SetActive(false);
    }

    public void nexttwo()
    {
        UIImagethird.SetActive(true);
        UIbackBtu2.SetActive(true);
        UIImageSecond.SetActive(false);
        UInextBtu2.SetActive(false);
    }

    public void Backone()
    {
        UIImagefirst.SetActive(true);
        UInextBtu.SetActive(true);
        UIImageSecond.SetActive(false);
        UIbackBtu.SetActive(false);
        UInextBtu2.SetActive(false);
    }

    public void Backtwo()
    {
        UIImagethird.SetActive(false);
        UIbackBtu2.SetActive(false);
        UIImageSecond.SetActive(true);
        UInextBtu2.SetActive(true);
        UIbackBtu.SetActive(true);
    }



    public void Load()
    {
        SceneManager.LoadScene("IntroScene");
        if(IntroManager.FirstPlay == 1)
        {
            LoddingManager.LoadScene("IntroScene");;
        }
        else if(IntroManager.FirstPlay <= 0)
        {
            LoddingManager.LoadScene("MainGame"); 
        }
        PlayerMove.EnterHome = 0;
        Timer.currenttime = 0;
        PlayerPrefs.SetFloat("Time", Timer.currenttime);
        PlayerPrefs.Save();
    }

    public void MainScene()
    {
        PlayerMove.EnterHome = 0;
        Timer.currenttime = 0;
        PlayerPrefs.SetFloat("Time", Timer.currenttime);
        PlayerPrefs.Save();
        LoddingManager.LoadScene("MainGame");
    }

    public void achievScene()
    {
        SceneManager.LoadScene("Achievment");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("IntScene");
    }
}
