using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperty : Health
{
    [SerializeField] PlayerHUD playerhud;
    [SerializeField] GameController gamecontroller;
    [SerializeField] bgmManager bgmManager;
    [SerializeField] Image HurtFade;
    [SerializeField] Image HealFade;
    [SerializeField] Image ManaFade;
    [SerializeField] AudioClip Hurt;
    [SerializeField] AudioSource audio;
    Enemy enemy;
    int maxMana = 12;
    int currentMana;
    int mana;

    int maxArmor = 100;
    int armor;

    int turn;

    int currentAttackBoostVal;
    int attackboostVal;

    int currentHealth;
    int maxHealth;

    int remaining;

    bool isDead = false;

    public bool _isDead { get => isDead; }
    public int _mana { get => mana; set => mana = value; }
    public int _armor { get => armor; set => armor = value; }
    public int _attackboostVal { get => attackboostVal; set => attackboostVal = value; }
    public int _turn { get => turn; set => turn = value; }
    public int _remaining { get => remaining; set => remaining = value; }
    private void Awake()
    {
        remaining = 3;
        enemy = FindObjectOfType<Enemy>();
        gamecontroller = FindObjectOfType<GameController>();
        bgmManager = FindObjectOfType<bgmManager>();
        playerhud.setMaxHealth(_health);
        playerhud.setMaxMana(maxMana);
        playerhud.setMaxArmor(maxArmor);
        playerhud.updateHealthBar();
        playerhud.updateManaBar();
        playerhud.updateArmorBar();
        playerhud.updateAttack();
        currentHealth = _health;
        maxHealth = _health;
        currentMana = mana;
    }

    public void attackBoostDuration()
    {
        if(_attackboostVal > currentAttackBoostVal)
        {
            playerhud.updateAttack();
            currentAttackBoostVal = _attackboostVal;
        }
    }

    public void CanHeal(int value)
    {
        if (_health >= currentHealth)
        {
            _health = currentHealth;
        }
        else
        {
            _health += value;
            if(_health > maxHealth)
            {
                _health = maxHealth;
            }
            playerhud.updateHealthBar();
        }
        StartCoroutine(HealSequence());
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
        if(mana >= maxMana)
        {
            mana = maxMana;
        }
        StartCoroutine(ManaSequence());
        playerhud.updateManaBar();
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
        if (_health <= 0)
        {
            Die();
        }
        StartCoroutine(HurtSequence());
        playerhud.updateHealthBar();
        playerhud.updateArmorBar();
    }

    IEnumerator HurtSequence()
    {
        audio.PlayOneShot(Hurt);
        HurtFade.gameObject.SetActive(true);
        HurtFade.CrossFadeAlpha(0, 0, false);
        HurtFade.CrossFadeAlpha(.5f, .25f, false);
        yield return new WaitForSeconds(.25f);
        HurtFade.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1);
        HurtFade.gameObject.SetActive(false);
    }

    IEnumerator HealSequence()
    {
        HealFade.gameObject.SetActive(true);
        HealFade.CrossFadeAlpha(0, 0, false);
        HealFade.CrossFadeAlpha(.5f, .1f, false);
        yield return new WaitForSeconds(.1f);
        HealFade.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1);
        HealFade.gameObject.SetActive(false);
    }

    IEnumerator ManaSequence()
    {
        ManaFade.gameObject.SetActive(true);
        ManaFade.CrossFadeAlpha(0, 0, false);
        ManaFade.CrossFadeAlpha(.5f, .1f, false);
        yield return new WaitForSeconds(.1f);
        ManaFade.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1);
        ManaFade.gameObject.SetActive(false);
    }

    public override void Heal(int value)
    {
        _health += value;
        playerhud.updateHealthBar();
    }

    protected override void Die()
    {
        isDead = true;
        StartCoroutine(deathMenuSeq());
    }

    IEnumerator deathMenuSeq()
    {
        yield return new WaitForSeconds(1f);
        bgmManager.playDeathbgm();
        gamecontroller.DeathMenu();
    }

}
