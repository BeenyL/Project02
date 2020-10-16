using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 1;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damagable
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if(objectToDamage != null)
        {
            objectToDamage.TakeDamage(_damageAmount);
            Debug.Log("add damage to the target");

        }
        else
        {
            Debug.Log("target is not damageable. . .");
        }
    }
}
