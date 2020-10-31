using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawState : BattleState
{
    bool _activated = false;

    GameManager _GameManager;

    public override void Enter()
    {
        print("Enter: Player Draw State");
        DrawCard();
        _activated = true;
    }

    public override void Tick()
    {
        if (_activated == true)
        {
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }

    public override void Exit()
    {
        print("Exit: Player Draw State");
        _activated = false;
    }

    private void DrawCard()
    {
        // draw card
    }
}
