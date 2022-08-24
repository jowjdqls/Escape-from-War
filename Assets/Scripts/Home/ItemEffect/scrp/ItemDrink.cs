using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Drink")]
public class ItemDrink : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curWa += 20;
        return true;
    }
}
