using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/ArmyFood")]
public class ItemArmyFood : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curhu += 50;
        return true;
    }    
}
