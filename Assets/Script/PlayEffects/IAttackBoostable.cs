using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/AttackBoost")]
public class IAttackBoostable : CardEffect
{
    public override void Activate()
    {
        Debug.Log("Attack boost PlayEffect played");
    }
}
