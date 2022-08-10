using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Bag")]
public class ItemBag : ItemEffect
{
    public override bool ExecuteRole()
    {
        InventoryUI.inven.SlotCnt += 2;
        return true;
    }
}
