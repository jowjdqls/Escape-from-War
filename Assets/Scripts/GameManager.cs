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

    

    public PlayerMove player;

    void Awake()
    {
        UIEnterStation.SetActive(false);
        UIExitStation.SetActive(false);
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
    

    public void IntStation()
    {
        player.Station();
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
}
