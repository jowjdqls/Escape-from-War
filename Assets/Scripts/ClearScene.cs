using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AchievmentManager.eight = 1;
        PlayerPrefs.SetInt("EightAch", AchievmentManager.eight);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
