using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/Mana")]
public class IManable : CardEffect
{
    public override void Activate()
    {
        Debug.Log("mana PlayEffect played");
    }
}
