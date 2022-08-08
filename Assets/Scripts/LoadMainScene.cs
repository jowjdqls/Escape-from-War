using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public GameObject UIBackGround;
    public GameObject UIImagefirst;
    public GameObject UIImageSecond;
    public GameObject UIcloseBtu;
    public GameObject UInextBtu;
    public GameObject UIbackBtu;

    public void Start()
    {
        UIBackGround.SetActive(false);
        UIImagefirst.SetActive(false);
        UIImageSecond.SetActive(false);
        UInextBtu.SetActive(false);
        UIbackBtu.SetActive(false);
        UIcloseBtu.SetActive(false);
    }

    public void help()
    {
        UIBackGround.SetActive(true);
        UIImagefirst.SetActive(true);
        UInextBtu.SetActive(true);
        UIcloseBtu.SetActive(true);
    }

    public void closehelp()
    {
        UIImagefirst.SetActive(false);
        UIBackGround.SetActive(false);
        UIImageSecond.SetActive(false);
        UInextBtu.SetActive(false);
        UIbackBtu.SetActive(false);
        UIcloseBtu.SetActive(false);
    }

    public void nexthelp()
    {
        UIImageSecond.SetActive(true);
        UInextBtu.SetActive(false);
        UIbackBtu.SetActive(true);
        UIImagefirst.SetActive(false);
    }

    public void backhelp()
    {
        UIImageSecond.SetActive(false);
        UInextBtu.SetActive(true);
        UIbackBtu.SetActive(false);
        UIImagefirst.SetActive(true);
    }

    public void Load()
    {
        SceneManager.LoadScene("IntroScene");
        if(IntroManager.FirstPlay == 1)
        {
            SceneManager.LoadScene("IntroScene");
        }
        else if(IntroManager.FirstPlay <= 0)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void achievScene()
    {
        SceneManager.LoadScene("Achievment");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
