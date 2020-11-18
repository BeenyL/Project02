using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] EnemyHUD enemyhud;
    [SerializeField] GameObject enemySelPanel;
    [SerializeField] PlayerProperty playerprop;
    [SerializeField] Transform defaultSelPos;
    [SerializeField] MonsterAnimation animator;
    [SerializeField] int Dmg = 5;
    EnemySelector enemyselector;
    GameController gamecontoller;
    bool isDead;
    bool isSelected;
    int currenthealth;
    int maxProb;
    public int _currenthealth => currenthealth;
    public bool _isSelected { get => isSelected; set => isSelected = value; }
    private void Awake()
    {
        animator = GetComponent<MonsterAnimation>();
        gamecontoller = FindObjectOfType<GameController>();
        enemyselector = FindObjectOfType<EnemySelector>();
        enemyhud.setMaxHealth(_health);
        currenthealth = _health;
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
        //set all enemies active once the wave is done.
        Dmg += Random.Range(1, 4);
        _health += Random.Range(10, 50);
        maxProb = Random.Range(1, 10);
    }
}
