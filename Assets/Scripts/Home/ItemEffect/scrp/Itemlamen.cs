using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/lamen")]
public class Itemlamen : ItemEffect
{
    public override bool ExecuteRole()
    {
        PlayerMove.curhu += 20;
        PlayerMove.curWa -= 40;
        return true;
    }
}


