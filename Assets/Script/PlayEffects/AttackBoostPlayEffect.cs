using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_PlayeEffect", menuName = "CardData/PlayEffects/AttackBoost")]
public class AttackBoostPlayEffect : CardEffect
{
    [SerializeField] int _attackBoostValue;
    PlayerProperty playerprop;

    public override void Activate()
    {
        playerprop = FindObjectOfType<PlayerProperty>();
        playerprop._attackboostVal = _attackBoostValue;
    }
}
