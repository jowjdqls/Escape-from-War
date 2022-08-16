using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/CarKey")]
public class ItemCarkey : ItemEffect
{
    public override bool ExecuteRole()
    {
        GameManager.CarKey += 1;
        return true;
    }    
}
