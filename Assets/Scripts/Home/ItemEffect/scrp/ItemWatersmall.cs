using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemEft/Consumable/Watersmall")]
public class ItemWatersmall : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curWa += 15;
        return true;
    }
}
