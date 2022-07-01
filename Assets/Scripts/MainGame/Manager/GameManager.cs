using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Stages;
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public GameObject UIEnterStation;
    public GameObject UIExitStation;
    public GameObject UIUseCar;
    public GameObject UIArmy;
    public GameObject UIArmyTalk;
    public GameObject CarObj;
    public GameObject Armybtu;

    public PlayerMove player;

    void Awake()
    {
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(false);
        UIArmy.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void NextStage()
    {
        totalPoint += stagePoint;
        stagePoint = 0;
        

        if (stageIndex == Stages.Length - 1)
        {
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);

            player.respown();
        }
    }

    public void Ontext()
    {
        UIEnterStation.SetActive(true);
    }
    
    //역 들어가기
    public void IntStation()
    {
        player.offCharacter();
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(true);
    }

    public void IntStationNo()
    {
        UIEnterStation.SetActive(false);
    }

    public void ExitStation()
    {
        player.Oncharacter();
        UIExitStation.SetActive(false);
    }

    //차 들어갈 때
    public void IntCar()
    {
        UIUseCar.SetActive(true);
    }

    public void IntCarYes()
    {
        player.offCharacter();
        UIUseCar.SetActive(false);
        UIArmy.SetActive(true);
        UIArmyTalk.SetActive(true);
        Armybtu.SetActive(true);
    }

    public void IntCarNo()
    {
        UIUseCar.SetActive(false);
    }

    public void IntCarYesAnswer()
    {
        UIUseCar.SetActive(false);
        UIArmy.SetActive(false);
        UIArmyTalk.SetActive(false);
        CarObj.SetActive(false);
        Armybtu.SetActive(false);
        player.Oncharacter();
    }
}
