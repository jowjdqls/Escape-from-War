using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInBlack : MonoBehaviour
{
    float time = 0;

    void Update()
    {
        if(time < 3f)
        {
            GetComponent<Text>().color = new Color(0, 0, 0, time/3);
        }
        else
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }
}
