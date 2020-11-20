﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Health
{
    [SerializeField] EnemyHUD enemyhud;
    [SerializeField] GameObject enemySelPanel;
    [SerializeField] PlayerProperty playerprop;
    [SerializeField] Transform defaultSelPos;
    [SerializeField] MonsterAnimation animator;

    [SerializeField] Image spriteImg;
    [SerializeField] Sprite monster;
    [SerializeField] Sprite boss;

    [SerializeField] Text enemyText;

    [SerializeField] bgmManager bmgmanger;

    [SerializeField] int Dmg = 5;
    EnemySelector enemyselector;
    GameController gamecontoller;
    SaveManager savemanager;

    bool isDead;
    bool isSelected;
    bool ifBoss = false;
    int currenthealth;
    int maxHealth;
    int maxProb;
    public int _currenthealth => currenthealth;
    public bool _isSelected { get => isSelected; set => isSelected = value; }
    public bool _isBoss { get => ifBoss; }
    private void Awake()
    {
        enemyText.text = "Oreling";
        animator = GetComponent<MonsterAnimation>();
        bmgmanger = FindObjectOfType<bgmManager>();
        gamecontoller = FindObjectOfType<GameController>();
        enemyselector = FindObjectOfType<EnemySelector>();
        currenthealth = _health;
        maxHealth = _health;
        enemyhud.setMaxHealth(_health);
        enemyhud.updateEnemyHealth();
        maxProb = 5;
    }

    public void CheckHealth()
    {
        if(_health < currenthealth)
        {
            animator.Hurt_Animation();
            enemyhud.updateEnemyHealth();
            currenthealth = _health;
        }
        if(_health <= 0)
        {
            StartCoroutine(DeathSequence());
            _health = 0;
            CheckWinCondition();
        }
    }

    IEnumerator DeathSequence()
    {
        isDead = true;
        enemySelPanel.transform.position = defaultSelPos.position;
        enemySelPanel.SetActive(false);
        enemyselector._enemychose = false;
        playerprop._remaining -= 1;
        animator.Die_Animation();
        ifBoss = false;
        yield return new WaitForSeconds(.5f);
        Die();
        Debug.Log(playerprop._remaining);
    }

    public void AttackPattern()
    {
        int probability = Random.Range(1, 10);

        if (probability > maxProb && isDead == false)
        {
            animator.Attack_Animation();
            playerprop.TakeDamage(Dmg);
        }
        else
        {
            enemyhud.setEnemyText("...Grrahhhh...");
        }

    }

    public void CheckWinCondition()
    {
        if(playerprop._remaining <= 0)
        {

            gamecontoller.WinMenu();
        }
    }

    public void Respawn()
    {
        savemanager = FindObjectOfType<SaveManager>();
        int isBoss = Random.Range(1, 10);
        ifBoss = false;
        if (isBoss == 5 && savemanager.currentLevel > 1)
        {
            enemyText.text = "Ore Overlord";
            ifBoss = true;
            Dmg += Random.Range(4, 6);
            maxHealth += Random.Range(35, 50);
            maxProb = Random.Range(1, 10);
            spriteImg.sprite = boss;
            spriteImg.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else
        {
            enemyText.text = "Oreling";
            ifBoss = false;
            Dmg += Random.Range(1, 3);
            maxHealth += Random.Range(5, 20);
            maxProb = Random.Range(1, 10);
            spriteImg.sprite = monster;
            spriteImg.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        updateEnemies();
    }

    void updateEnemies()
    {
        playerprop._remaining = 3;
        Refresh_Attributes();
        isDead = false;
        gameObject.SetActive(true);
        animator.Idle_Animation();
        bmgmanger.playbgm();
    }

    public void Refresh_Attributes()
    {
        _health = maxHealth;
        enemyhud.setMaxHealth(_health);
        currenthealth = _health;
        enemyhud.updateEnemyHealth();
    }

}
