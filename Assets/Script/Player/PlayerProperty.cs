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
        if(armor > 0)
        {

        }

        if(_health < currentHealth || _health > currentHealth && armor == 0)
        {
            playerhud.updateHealthBar();
            currentHealth = _health;
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

    public override void TakeDamage(int value)
    {
        int leftoverDmg;
        if(armor > 0)
        {
            value -= armor;
            if(value < 0)
            {
                leftoverDmg = value;
                armor = Mathf.Abs(leftoverDmg);
            }
            else
            {
                armor = 0;
                currentHealth -= value;
            }

        }
    }

    protected override void Die()
    {
        if(currentHealth <= 0)
        {
            //set gameover state
        }

    }
}
