using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] EnemyHUD enemyhud;
    [SerializeField] GameObject enemySelPanel;
    [SerializeField] PlayerProperty playerprop;
    [SerializeField] Transform defaultSelPos;
    EnemySelector enemyselector;
    GameController gamecontoller;
    bool isDead;
    int currenthealth;
    public int _currenthealth => currenthealth;
    private void Awake()
    {
        gamecontoller = FindObjectOfType<GameController>();
        enemyselector = FindObjectOfType<EnemySelector>();
        enemyhud.setMaxHealth(_health);
        currenthealth = _health;
        enemyhud.updateEnemyHealth();
    }

    public void CheckHealth()
    {
        if(_health < currenthealth)
        {
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
        yield return new WaitForSeconds(.5f);
        Die();
        Debug.Log(playerprop._remaining);
    }

    public void AttackPattern()
    {
        int probability = Random.Range(1, 10);

        if (probability > 5 && isDead == false)
        {
            playerprop.TakeDamage(5);
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
}
