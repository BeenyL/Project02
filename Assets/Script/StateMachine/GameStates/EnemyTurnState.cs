using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnState : BattleState
{
    [SerializeField] float _enemyTurnDuration = 3;
    [SerializeField] Image enemyturnindicator;
    [SerializeField] Image stopPlayerAction;
    [SerializeField] Enemy[] enemy;
    [SerializeField] EnemyHUD[] enemyhud;

    public override void Enter()
    {
        enemyturnindicator.enabled = true;
        stopPlayerAction.gameObject.SetActive(true);
        StartCoroutine(EnemyTurn());
        StartCoroutine(TakeTurn());
    }

    public override void Tick()
    {

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(_enemyTurnDuration);
        StateMachine.ChangeState<PlayerDrawState>();
    }

    IEnumerator TakeTurn()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 3; i++)
        {
            enemy[i].AttackPattern();
        }
        
    }

    public override void Exit()
    {
        enemyturnindicator.enabled = false;
        stopPlayerAction.gameObject.SetActive(false);
        for(int i = 0; i < 3; i++)
        {
            enemyhud[i].setEnemyText(" ");
        }
    }
}
