using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Wallet")]
public class ItemWallet : ItemEffect
{
    public override bool ExecuteRole()
    {
        GameManager.WalletP +=1;
        return true;
    }
}
