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

    public GameObject UIBoxText;
    public GameObject UIoutBox;

    public GameObject UIesctext;

    public GameObject UIUseCar;
    public GameObject UIArmy;
    public GameObject UIArmyTalk;
    public GameObject CarObj;
    public GameObject Armybtu;

    public GameObject MartText;

    public GameObject pharmacyText;
    public GameObject UIpharmacy;

    public PlayerMove player;

    public static bool StopGame;

    public static int WalletP = 0;
    public static int CarKey = 0;

    void Awake()
    {
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(false);
        UIArmy.SetActive(false);
        UIesctext.SetActive(false);
    }

    void Start()
    {
        StopGame = false;
        AchievmentManager.one = PlayerPrefs.GetInt("OneAch");
        AchievmentManager.two = PlayerPrefs.GetInt("TwoAch");
        Timer.currenttime = PlayerPrefs.GetFloat("Time");
        //PlayerPrefs.DeleteKey("Time");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIesctext.SetActive(true);
            StopGameTime();
            player.StopPlayer();
        }
    }

    public void NextStage()
    {
        totalPoint += stagePoint;
        stagePoint = 0;
        

        if (stageIndex == Stages.Length - 1)
        {
            SceneManager.LoadScene("EndScene");
            AchievmentManager.eight = 1;
            PlayerPrefs.SetInt("EightAch", AchievmentManager.eight);
            PlayerPrefs.Save();
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

        var enemys = FindObjectsOfType<EnemyMove>();
        foreach (var EnemyMove in enemys)
        {
            Destroy(EnemyMove.gameObject);
        }

        var builds = FindObjectsOfType<build>();
        foreach (var build in builds)
        {
            Destroy(build.gameObject);
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

    public void escX()
    {
        UIesctext.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    public void escMenu()
    {
        SceneManager.LoadScene("IntScene");
        StartGameTime();
        player.StartPlayer();
    }

    public void escRePlay()
    {
        SceneManager.LoadScene("MainGame");
        StartGameTime();
        player.StartPlayer();
        Timer.currenttime = 0;
        PlayerPrefs.SetFloat("Time", Timer.currenttime);
        PlayerPrefs.Save();
    }

    public void escQuit()
    {
        Application.Quit();
    }

    //역 들어가기 텍스트
    public void Ontext()
    {
        UIEnterStation.SetActive(true);
    }

    //박스
    public void OnBoxText()
    {
        UIBoxText.SetActive(true);
    }

    public void OnBoxYes()
    {
        player.noPlayer();
        UIBoxText.SetActive(false);
        UIoutBox.SetActive(true);
        StartGameTime();
        player.StartPlayer();
    }

    public void OnBoxNo()
    {
        UIBoxText.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    public void OutBox()
    {
        UIoutBox.SetActive(false);
        player.yesPlayer();
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
        PlayerMove.curhu += 50;
        PlayerMove.curWa += 50;
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
        PlayerMove.curHp += 70;
        player.HospitalP -= 1;
        if(AchievmentManager.two == 0)
        {
            AchievmentManager.two ++;
            PlayerPrefs.SetInt("TwoAch", AchievmentManager.two);
            PlayerPrefs.Save();
        }
        else if(AchievmentManager.two == 1)
        {
            AchievmentManager.two = 1;
        }
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
        StartGameTime();
        player.StartPlayer();
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
        if(AchievmentManager.one == 0)
        {
            AchievmentManager.one++;
            PlayerPrefs.SetInt("OneAch", AchievmentManager.one);
            PlayerPrefs.Save();
        }
        else if (AchievmentManager.one == 1)
        {
            AchievmentManager.one = 1;
        }
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

    public void Escbtu()
    {
        UIesctext.SetActive(true);
        StopGameTime();
        player.StopPlayer();
    }

    //약국 들어가기
    public void IntPharmacy()
    {
        pharmacyText.SetActive(true);
    }

    public void IntPharmacyYes()
    {
        pharmacyText.SetActive(false);
        UIpharmacy.SetActive(true);
        AchievmentManager.six = 1;
        PlayerPrefs.SetInt("SixAch", AchievmentManager.six);
        PlayerPrefs.Save();
    }

    public void IntPharmacyNo()
    {
        pharmacyText.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    public void BackPharmacy()
    {
        UIpharmacy.SetActive(false);
        StartGameTime();
        player.StartPlayer();
    }

    //마트 들어가기
    public void IntMart()
    {
        MartText.SetActive(true);
    }

    public void IntMartYes()
    {

    }

    public void IntMartNo()
    {
        
    }
}
