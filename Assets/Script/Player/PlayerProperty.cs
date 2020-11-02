using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : Health
{
    [SerializeField] PlayerHUD playerhud;
    int maxMana = 10;
    int currentMana;
    int mana;

    int maxArmor = 100;
    int currentArmor;
    int armor;

    int attackboostVal;

    int currentHealth;
    public int _mana { get => mana; set => mana = value; }
    public int _armor { get => armor; set => armor = value; }
    public int _attackboostVal { get => attackboostVal; set => attackboostVal = value; }

    private void Awake()
    {
        playerhud.setMaxHealth(_health);
        playerhud.setMaxMana(maxMana);
        playerhud.setMaxArmor(maxArmor);
        playerhud.updateHealthBar();
        playerhud.updateManaBar();
        playerhud.updateArmorBar();
        currentArmor = 0;
        currentHealth = _health;
        currentMana = mana;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Heal(5);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            mana++;
            playerhud.updateManaBar();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            addArmor(5);
        }

    }

    public void CanHeal(int value)
    {
        Heal(value);
        if (currentHealth >= _health)
        {
            currentHealth = _health;
        }
    }

    public void ManaRefresh()
    {
        currentMana++;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        mana = currentMana;
        playerhud.updateManaBar();
    }

    public void addArmor(int value)
    {
        armor += value;
        playerhud.updateArmorBar();
    }

    public void addMana(int value)
    {
        mana += value;
        playerhud.updateArmorBar();
    }

    public override void TakeDamage(int value)
    {
        if(armor > 0)
        {
            value -= armor;
            if(value < 0)
            {
                armor = Mathf.Abs(value);
            }
            if(value == 0)
            {
                armor = 0;
            }
            if(value > 0)
            {
                armor = 0;
                _health -= value;
            }
        }
        else
        {
            _health -= value;
        }

        playerhud.updateHealthBar();
        playerhud.updateArmorBar();
    }

    protected override void Die()
    {
        if(currentHealth <= 0)
        {
            //set gameover state
        }

    }
}
