using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_PlayeEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayEffect : CardEffect
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] bool _aoe = false;
    PlayerProperty playerprop;
    EnemySelector enemyselecter;
    Enemy enemy;
    Enemy[] allEnemy;
    public bool is_aoe => _aoe;

    public override void Activate()
    {
        enemyselecter = FindObjectOfType<EnemySelector>();
        playerprop = FindObjectOfType<PlayerProperty>();

        if(_aoe == true)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach(Enemy e in enemies)
            {
                e.TakeDamage(_damageAmount + playerprop._attackboostVal);
                e.CheckHealth();
            }
        }
        else
        {
            enemy = enemyselecter._enemy;
            enemy.TakeDamage(_damageAmount + playerprop._attackboostVal);
            enemy.CheckHealth();
        }
    }
}
