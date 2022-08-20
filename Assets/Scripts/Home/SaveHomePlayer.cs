using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHomePlayer : MonoBehaviour
{
    public static SaveHomePlayer P_instance = null;
    
    void Awake() 
    {
        //DontDestroyOnLoad(this.gameObject);
        if (P_instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }    

        P_instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void DestroyHomePlayer()
    {
        Destroy(this.gameObject);
    }
}
