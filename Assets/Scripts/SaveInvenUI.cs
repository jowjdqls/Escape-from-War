using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInvenUI : MonoBehaviour
{
    public static SaveInvenUI instance = null;
    
    void Awake() 
    {
        if (instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }    

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void DestroyUI()
    {
        Destroy(this.gameObject);
    }
}
