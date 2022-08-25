using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManaagerHard : MonoBehaviour
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
    public GameObject NoCarKey;
    public GameObject UIArmy;
    public GameObject UIArmyTalk;
    public GameObject CarObj;
    public GameObject Armybtu;

    public GameObject UInomoney;
    public GameObject MartText;
    public GameObject UImart;

    public GameObject pharmacyText;
    public GameObject UIpharmacy;

    public GameObject MilitaryText;

    public PlayerMoveHard playerhard;

    public static bool StopGame;

    public static int WalletP = 0;
    public static int CarKey = 0;

    void Awake()
    {
        WalletP = 0;
        CarKey = 0;
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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIesctext.SetActive(true);
            StopGameTime();
            playerhard.StopPlayer();
        }
    }

    public void NextStage()
    {
        totalPoint += stagePoint;
        stagePoint = 0;
        

        if (stageIndex == Stages.Length - 1)
        {
            SceneManager.LoadScene("EndScene");
            SaveHomePlayer.P_instance.DestroyHomePlayer();
            SaveInvenUI.instance.DestroyUI();
            AchievmentManager.ten = 1;
            PlayerPrefs.SetInt("TenAch", AchievmentManager.ten);
            PlayerPrefs.Save();
        }
        else
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);

            playerhard.respown();
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
        playerhard.StartPlayer();
    }

    public void escMenu()
    {
        if(PlayerMove.EnterHome == 1)
        {
            SaveInvenUI.instance.DestroyUI();
            SaveHomePlayer.P_instance.DestroyHomePlayer();
            SceneManager.LoadScene("IntScene");
            PlayerMove.EnterHome = 0;
            Timer.currenttime = 0;
            PlayerPrefs.SetFloat("Time", Timer.currenttime);
            PlayerPrefs.Save();
            StartGameTime();
            playerhard.StartPlayer();
        }
        else if(PlayerMove.EnterHome == 0)
        {
            SceneManager.LoadScene("IntScene");
            StartGameTime();
            playerhard.StartPlayer();
            Timer.currenttime = 0;
            PlayerPrefs.SetFloat("Time", Timer.currenttime);
            PlayerPrefs.Save();
        }
    }

    public void escRePlay()
    {
        if(PlayerMove.EnterHome == 1)
        {
            SaveInvenUI.instance.DestroyUI();
            SaveHomePlayer.P_instance.DestroyHomePlayer();
            SceneManager.LoadScene("MainGame");
            StartGameTime();
            playerhard.StartPlayer();
            Timer.currenttime = 0;
            PlayerMove.EnterHome = 0;
            PlayerPrefs.SetFloat("Time", Timer.currenttime);
            PlayerPrefs.Save();
        }
        else if(PlayerMove.EnterHome == 0)
        {
            SceneManager.LoadScene("MainGame");
            StartGameTime();
            playerhard.StartPlayer();
            Timer.currenttime = 0;
            PlayerPrefs.SetFloat("Time", Timer.currenttime);
            PlayerPrefs.Save();
        }
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
        playerhard.noPlayer();
        UIBoxText.SetActive(false);
        UIoutBox.SetActive(true);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void OnBoxNo()
    {
        UIBoxText.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void OutBox()
    {
        UIoutBox.SetActive(false);
        playerhard.yesPlayer();
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
        playerhard.StartPlayer();
    }

    public void OnTentYes()
    {
        UITentText.SetActive(false);
        PlayerMove.curhu += 50;
        PlayerMove.curWa += 50;
        StartGameTime();
        playerhard.StartPlayer();
        playerhard.Gettent -= 1;
    }

    public void OnTentNo()
    {
        UITentText.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
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
        playerhard.GetHospital -= 1;
    }

    public void OnHospitalEnt()
    {
        UIHospitalEnter.SetActive(true);
    }

    public void OnHospitalEntYes()
    {
        UIHospitalEnter.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
        PlayerMove.curHp += 70;
        playerhard.HospitalP -= 1;
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
        playerhard.StartPlayer();
    }

    public void OnHospitalNoEnt()
    {
        UIHospitalNoEnt.SetActive(true);
    }

    public void OnHospitalNoEntAnswer()
    {
        UIHospitalNoEnt.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    //역 들어가기
    public void IntStation()
    {
        playerhard.offCharacter();
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(true);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void IntStationNo()
    {
        UIEnterStation.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void ExitStation()
    {
        playerhard.Oncharacter();
        StartGameTime();
        playerhard.StartPlayer();
        UIExitStation.SetActive(false);
    }

    //차 들어갈 때
    public void IntCar()
    {
        UIUseCar.SetActive(true);
    }

    public void DonotIntCar()
    {
        NoCarKey.SetActive(true);
    }

    public void DonotIntCarAnswer()
    {
        NoCarKey.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void IntCarYes()
    {
        playerhard.offCharacter();
        UIUseCar.SetActive(false);
        UIArmy.SetActive(true);
        UIArmyTalk.SetActive(true);
        Armybtu.SetActive(true);
        StartGameTime();
        playerhard.StartPlayer();
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
        playerhard.StartPlayer();
    }

    public void IntCarYesAnswer()
    {
        UIUseCar.SetActive(false);
        UIArmy.SetActive(false);
        UIArmyTalk.SetActive(false);
        CarObj.SetActive(false);
        Armybtu.SetActive(false);
        playerhard.Oncharacter();
    }

    public void Escbtu()
    {
        UIesctext.SetActive(true);
        StopGameTime();
        playerhard.StopPlayer();
    }

    //약국 들어가기

    public void NomoneyPharmacy()
    {
        UInomoney.SetActive(true);
    }

    public void NomoneyPharmacyAnswer()
    {
        UInomoney.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }
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
        playerhard.StartPlayer();
    }

    public void BackPharmacy()
    {
        UIpharmacy.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    //마트 들어가기
    public void IntMart()
    {
        MartText.SetActive(true);
    }

    public void IntMartYes()
    {
        MartText.SetActive(false);
        UImart.SetActive(true);
        AchievmentManager.twelve = 1;
        PlayerPrefs.SetInt("TwelAch", AchievmentManager.twelve);
        PlayerPrefs.Save();
    }

    public void IntMartNo()
    {
        MartText.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void BackMart()
    {
        UImart.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void MeetMilitaryCar()
    {
        MilitaryText.SetActive(true);
    }

    public void militaryNo()
    {
        MilitaryText.SetActive(false);
        StartGameTime();
        playerhard.StartPlayer();
    }

    public void militaryYes()
    {
        if(PlayerMove.EnterHome == 0)
        {
            SceneManager.LoadScene("MilitaryScene");
            AchievmentManager.eleven = 1;
            PlayerPrefs.SetInt("ElevAch", AchievmentManager.eleven);
            PlayerPrefs.Save();
            StartGameTime();
            playerhard.StartPlayer();
        }
        else if(PlayerMove.EnterHome == 1)
        {
            StartGameTime();
            playerhard.StartPlayer();
            AchievmentManager.eleven = 1;
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("ElevAch", AchievmentManager.eleven);
            SaveInvenUI.instance.DestroyUI();
            SaveHomePlayer.P_instance.DestroyHomePlayer();
            SceneManager.LoadScene("MilitaryScene");
        }
    }
}