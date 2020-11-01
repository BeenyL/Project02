using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/Heal")]
public class HealablePlayEffect : CardEffect
{
    [SerializeField] int _healAmount = 1;

    public override void Activate()
    {
        Debug.Log("HealablePlayEffect played");
    }
}
