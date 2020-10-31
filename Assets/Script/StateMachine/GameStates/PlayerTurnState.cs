using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnState : BattleState
{
    [SerializeField] PlayerProperty playerprop;
    [SerializeField] Image playerturnindicator;
    public override void Enter()
    {
        playerturnindicator.enabled = true;
        print("Enter: Player Turn");
        playerprop.ManaRefresh();
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        print("Exit: Player Turn");
    }

    public void EndPlayerTurn()
    {
        playerturnindicator.enabled = false;
        StateMachine.ChangeState<EnemyTurnState>();
    }
}
