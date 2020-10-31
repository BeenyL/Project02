using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] EnemyHUD enemyhud;
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
        CheckHealth();
    }

    void CheckHealth()
    {
        if(_health < currenthealth)
        {
            enemyhud.updateEnemyHealth();
            currenthealth = _health;
        }
    }

}
