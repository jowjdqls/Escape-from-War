using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Curry")]
public class ItemCurry : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curhu += 30;
        return true;
    }
}
