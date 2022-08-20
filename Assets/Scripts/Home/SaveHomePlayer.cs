using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHomePlayer : MonoBehaviour
{
    //public static SaveHomePlayer P_instance = null;
    
    void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        /*if (P_instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }    

        P_instance = this;
        DontDestroyOnLoad(this.gameObject);*/
    }
}
