using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] EnemyHUD enemyhud;
    [SerializeField] PlayerProperty playerprop;
    int currenthealth;
    public int _currenthealth => currenthealth;
    private void Awake()
    {
        enemyhud.setMaxHealth(_health);
        currenthealth = _health;
        enemyhud.updateEnemyHealth();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            TakeDamage(5);
            enemyhud.updateEnemyHealth();
        }
    }

    public void CheckHealth()
    {
        if(_health < currenthealth)
        {
            enemyhud.updateEnemyHealth();
            currenthealth = _health;
        }
    }

    public void AttackPattern()
    {
        int probability = Random.Range(1, 10);

        if(probability > 5)
        {
            playerprop.TakeDamage(5);
        }
        else
        {
            enemyhud.setEnemyText("...Grrahhhh...");
        }

    }

}
