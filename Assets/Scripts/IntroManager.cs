using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject Intro1;
    public GameObject Intro2;
    public GameObject Intro3;
    public GameObject Intro4;

    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;

    public AudioClip Sound;

    AudioSource audioSource;

    public static float StartTime;

    public static int FirstPlay = 1;

    enum EmergencySound
    {
        Openning
    }

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(EmergencySound action)
    {
        switch(action)
        {
            case EmergencySound.Openning : audioSource.clip = Sound;
                break;
        }
    }

    public void Start()
    {
        Intro1.SetActive(true);
        Text1.SetActive(true);

        Intro2.SetActive(false);
        Intro3.SetActive(false);
        Intro4.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);

        StartTime = 20.0f;

        FirstPlay = PlayerPrefs.GetInt("FirstP");
    }

    public void Update()
    {
        StartTime -= Time.deltaTime;
        if(StartTime <= 17)
        {
            Intro1.SetActive(false);
            Text1.SetActive(false);

            Intro2.SetActive(true);
            Text2.SetActive(true);
        }
        if(StartTime <= 14)
        {
            Intro2.SetActive(false);
            Text2.SetActive(false);

            Intro3.SetActive(true);
            Text3.SetActive(true);

            PlaySound(EmergencySound.Openning);
        }
        if(StartTime <= 11)
        {
            Intro3.SetActive(false);
            Text3.SetActive(false);

            Intro4.SetActive(true);
            Text4.SetActive(true);
        }
        if(StartTime <= 7)
        {
            FirstPlay --;
            PlayerPrefs.SetInt("FirstP", FirstPlay);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainGame");
        }
    }

    public void skip1()
    {
        StartTime = 17; 
    }

    public void skip2()
    {
        StartTime = 14;
    }

    public void skip3()
    {
        StartTime = 11;
    }

    public void skip4()
    {
        StartTime = 7;
    }
}
