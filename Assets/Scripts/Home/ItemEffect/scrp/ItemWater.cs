using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Water")]
public class ItemWater : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curWa += 30;
        return true;
    }
}
