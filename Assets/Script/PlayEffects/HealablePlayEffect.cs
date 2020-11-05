using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_PlayeEffect", menuName = "CardData/PlayEffects/Heal")]
public class HealablePlayEffect : CardEffect
{
    [SerializeField] int _healAmount = 1;
    PlayerProperty playerprop;

    public override void Activate()
    {
        playerprop = FindObjectOfType<PlayerProperty>();
        playerprop.CanHeal(_healAmount);
    }
}
