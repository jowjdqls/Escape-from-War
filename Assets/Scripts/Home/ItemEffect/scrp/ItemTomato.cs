using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Tomato")]
public class ItemTomato : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curhu += 30;
        return true;
    }
}
