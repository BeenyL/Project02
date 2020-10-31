using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : Health
{
    [SerializeField] PlayerHUD playerhud;
    int maxMana = 10;
    int currentMana;
    int mana;
    int currentHealth;
    public int _mana => mana;

    private void Awake()
    {
        playerhud.setMaxHealth(300);
        playerhud.setMaxMana(10);
        playerhud.updateHealthBar();
        playerhud.updateManaBar();
        currentHealth = _health;
        currentMana = mana;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(5);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            mana++;
            playerhud.updateManaBar();
        }
        DamageCheck();
    }

    void DamageCheck()
    {
        if(_health < currentHealth || _health > currentHealth)
        {
            playerhud.updateHealthBar();
            currentHealth = _health;
        }
    }

    public void CanHeal(int value)
    {
        if(currentHealth >= _health)
        {

        }
        Heal(value);
    }

    public void ManaRefresh()
    {
        if(currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        currentMana++;
        mana = currentMana;
        playerhud.updateManaBar();
    }
}
