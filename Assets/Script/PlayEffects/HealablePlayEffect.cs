using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/Heal")]
public class HealablePlayEffect : CardPlayEffect
{
    [SerializeField] int _healAmount = 1;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damagable
        IHealable objectToHeal = target as IHealable;
        // if it is, apply damage
        if (objectToHeal != null)
        {
            objectToHeal.Heal(_healAmount);
            Debug.Log("heal to the target");

        }
        else
        {
            Debug.Log("target is not healable. . .");
        }
    }
}
