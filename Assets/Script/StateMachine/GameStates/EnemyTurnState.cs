using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnState : BattleState
{
    [SerializeField] float _enemyTurnDuration = 3;
    [SerializeField] Image enemyturnindicator;
    [SerializeField] Image stopPlayerAction;
    [SerializeField]Enemy[] enemy;

    public override void Enter()
    {
        enemyturnindicator.enabled = true;
        stopPlayerAction.gameObject.SetActive(true);
        print("Enter: Enemy Turn");
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
        print("Exit: Enemy Turn");
    }
}
