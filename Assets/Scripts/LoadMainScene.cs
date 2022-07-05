using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public GameObject UIBackGround;
    public GameObject UIBackGround2;
    public GameObject UIBackGround3;

    float Time;
    float checkTime;

    public void Load()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        invokebackRe();
    }

    public void invokebackRe()
    {
        InvokeRepeating("invokeback", 1f, 1f);
    }

    public void invokeback()
    {
        InvokeRepeating("ChangeBack", 5f, 5f);
        Invoke("InvokeCancle", 10f);
        InvokeRepeating("ChangeBack2", 10f, 5f);
        Invoke("InvokeCancle2", 15f);
        InvokeRepeating("ChangeBack3", 15f, 5f);
        Invoke("InvokeCancle3", 20f);
    }

    public void ChangeBack()
    {
        UIBackGround.SetActive(false);
        UIBackGround2.SetActive(true);
        UIBackGround3.SetActive(false);
    }

    public void ChangeBack2()
    {
        UIBackGround.SetActive(false);
        UIBackGround2.SetActive(false);
        UIBackGround3.SetActive(true);
    }

    public void ChangeBack3()
    {
        UIBackGround.SetActive(true);
        UIBackGround2.SetActive(false);
        UIBackGround3.SetActive(false);
    }

    private void InvokeCancle()
    {
        CancelInvoke("ChangeBack");
    }
    private void InvokeCancle2()
    {
        CancelInvoke("ChangeBack2");
    }
    private void InvokeCancle3()
    {
        CancelInvoke("ChangeBack3");
    }
}
