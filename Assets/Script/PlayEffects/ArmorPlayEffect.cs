using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_PlayeEffect", menuName = "CardData/PlayEffects/Armor")]
public class ArmorPlayEffect : CardEffect
{
    [SerializeField] int _armorAmount = 1;
    PlayerProperty playerprop;

    public override void Activate()
    {
        playerprop = FindObjectOfType<PlayerProperty>();
        playerprop.addArmor(_armorAmount);
    }
}
