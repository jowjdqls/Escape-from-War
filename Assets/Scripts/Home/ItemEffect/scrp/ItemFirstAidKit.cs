using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/FirstAidKit")]
public class ItemFirstAidKit : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curHp += 40;
        return true;
    }    
}
