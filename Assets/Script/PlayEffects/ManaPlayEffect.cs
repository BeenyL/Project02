using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_PlayeEffect", menuName = "CardData/PlayEffects/Mana")]
public class ManaPlayEffect : CardEffect
{
    [SerializeField] int _manaAmount = 1;
    PlayerProperty playerprop;
    public override void Activate()
    {
        playerprop = FindObjectOfType<PlayerProperty>();
        playerprop.addMana(_manaAmount);
    }
}
