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
        if(playerprop._turn > 0)
        {
            playerprop._turn--;
        }
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
