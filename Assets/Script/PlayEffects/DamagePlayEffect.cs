using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayeEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayEffect : CardEffect
{
    [SerializeField] int _damageAmount = 1;
    EnemySelector enemyselecter;
    Enemy enemy;

    public override void Activate()
    {
        enemyselecter = FindObjectOfType<EnemySelector>();
        enemy = enemyselecter._enemy;
        enemy.TakeDamage(_damageAmount);
        Debug.Log("damagePlayEffect played");
    }
}
