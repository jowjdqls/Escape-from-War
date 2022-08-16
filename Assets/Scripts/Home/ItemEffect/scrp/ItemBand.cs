using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Band")]
public class ItemBand : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curHp += 20;
        return true;
    }    
}
