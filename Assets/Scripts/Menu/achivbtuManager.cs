using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class achivbtuManager : MonoBehaviour
{
    public GameObject ExUI;
    public GameObject ExTextUI1;
    public GameObject ExTextUI2;
    public GameObject ExTextUI3;
    public GameObject ExTextUI4;
    public GameObject ExTextUI5;
    public GameObject ExTextUI6;
    public GameObject ExTextUI7;
    public GameObject ExTextUI8;
    public GameObject ExTextUI9;
    public GameObject ExTextUI10;
    public GameObject ExTextUI11;

    public void closebtu()
    {
        ExUI.SetActive(false);
        ExTextUI1.SetActive(false);
        ExTextUI2.SetActive(false);
        ExTextUI3.SetActive(false);
        ExTextUI4.SetActive(false);
        ExTextUI5.SetActive(false);
        ExTextUI6.SetActive(false);
        ExTextUI7.SetActive(false);
        ExTextUI8.SetActive(false);
        ExTextUI9.SetActive(false);
        ExTextUI10.SetActive(false);
        ExTextUI11.SetActive(false);
    }

    public void BackMain()
    {
        SceneManager.LoadScene("IntScene");
    }

    public void UI1btu()
    {
        ExUI.SetActive(true);
        ExTextUI1.SetActive(true);
    }

    public void UI2btu()
    {
        ExUI.SetActive(true);
        ExTextUI2.SetActive(true);
    }

    public void UI3btu()
    {
        ExUI.SetActive(true);
        ExTextUI3.SetActive(true);
    }

    public void UI4btu()
    {
        ExUI.SetActive(true);
        ExTextUI4.SetActive(true);
    }

    public void UI5btu()
    {
        ExUI.SetActive(true);
        ExTextUI5.SetActive(true);
    }

    public void UI6btu()
    {
        ExUI.SetActive(true);
        ExTextUI6.SetActive(true);
    }

    public void UI7btu()
    {
        ExUI.SetActive(true);
        ExTextUI7.SetActive(true);
    }

    public void UI8btu()
    {
        ExUI.SetActive(true);
        ExTextUI8.SetActive(true);
    }

    public void UI9btu()
    {
        ExUI.SetActive(true);
        ExTextUI9.SetActive(true);
    }

    public void UI10btu()
    {
        ExUI.SetActive(true);
        ExTextUI10.SetActive(true);
    }

    public void UI11btu()
    {
        ExUI.SetActive(true);
        ExTextUI11.SetActive(true);
    }
}
