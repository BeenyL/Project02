using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/Armor")]
public class IArmorable : CardEffect
{

    public override void Activate()
    {
        Debug.Log("Armor PlayEffect played");
    }
}
