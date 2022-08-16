using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Tshirts")]
public class ItemTshirt : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.maxHp += 20;
        return true;
    }
}
