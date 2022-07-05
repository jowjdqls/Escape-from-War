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

    public GameObject UITentText;
    public GameObject UITentNoGet;

    public GameObject UIHospitalText;
    public GameObject UIHospitalEnter;
    public GameObject UIHospitalNoEnt;

    public GameObject UIUseCar;
    public GameObject UIArmy;
    public GameObject UIArmyTalk;
    public GameObject CarObj;
    public GameObject Armybtu;

    public PlayerMove player;

    public static bool StopGame;

    void Awake()
    {
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(false);
        UIArmy.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        StopGame = false;
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

    public void DestroyClone()
    {
        var misiles = FindObjectsOfType<misile>();
        foreach (var misile in misiles)
        {
            Destroy(misile.gameObject);   
        }
        Destroy(GameObject.Find("airplane(Clone)")); 
        Destroy(GameObject.Find("airplaneHard(Clone)")); 
    }

    public void StopGameTime()
    {
        Time.timeScale = 0;
        StopGame = true;
        return;
    }

    public void StartGameTime()
    {
        Time.timeScale = 1;
        StopGame = false;
        return;
    }

    //역 들어가기 텍스트
    public void Ontext()
    {
        UIEnterStation.SetActive(true);
    }

    //배식 텍스트
    public void OnTenttext()
    {
        UITentText.SetActive(true);
    }

    public void OnTentGet()
    {
        UITentNoGet.SetActive(true);
    }

    public void OnTentGetBtu()
    {
        UITentNoGet.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    public void OnTentYes()
    {
        UITentText.SetActive(false);
        player.curhu += 40;
        player.curWa += 40;
        StartGameTime();
        player.StartPlayer();
        player.Gettent -= 1;
    }

    public void OnTentNo()
    {
        UITentText.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    //병원
    public void OnHospitalText()
    {
        UIHospitalText.SetActive(true);
    }

    public void OnHospitalTextAnswer()
    {
        UIHospitalText.SetActive(false);
        UIHospitalEnter.SetActive(true);
        player.GetHospital -= 1;
    }

    public void OnHospitalEnt()
    {
        UIHospitalEnter.SetActive(true);
    }

    public void OnHospitalEntYes()
    {
        UIHospitalEnter.SetActive(false);
        StartGameTime();
        player.StartPlayer();
        player.curHp += 50;
        player.HospitalP -= 1;
    }
    
    public void OnHospitalEntNo()
    {
        UIHospitalEnter.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    public void OnHospitalNoEnt()
    {
        UIHospitalNoEnt.SetActive(true);
    }

    public void OnHospitalNoEntAnswer()
    {
        UIHospitalNoEnt.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    //역 들어가기
    public void IntStation()
    {
        player.offCharacter();
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(true);
        StartGameTime();
        player.StartPlayer();
    }

    public void IntStationNo()
    {
        UIEnterStation.SetActive(false);
        StartGameTime();
        player.StartPlayer();
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
        StartGameTime();
        player.StartPlayer();
    }

    public void IntCarNo()
    {
        UIUseCar.SetActive(false);
        StartGameTime();
        player.StartPlayer();
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
