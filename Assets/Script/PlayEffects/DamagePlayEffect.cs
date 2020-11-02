using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_PlayeEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayEffect : CardEffect
{
    [SerializeField] int _damageAmount = 1;
    PlayerProperty playerprop;
    EnemySelector enemyselecter;
    Enemy enemy;

    public override void Activate()
    {
        enemyselecter = FindObjectOfType<EnemySelector>();
        playerprop = FindObjectOfType<PlayerProperty>();
        enemy = enemyselecter._enemy;
        enemy.TakeDamage(_damageAmount + playerprop._attackboostVal);
        enemy.CheckHealth();
        Debug.Log("damagePlayEffect played");
    }
}
