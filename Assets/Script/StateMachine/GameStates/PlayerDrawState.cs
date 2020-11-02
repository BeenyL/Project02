using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawState : BattleState
{
    bool _activated = false;

    GameManager gameManager;

    public override void Enter()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            // for front end deck
            gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - 1].transform.position = gameManager.cardPosTransforms[1].position;

            gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - 1].transform.parent = gameManager.cardPosTransforms[1];

            gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - 1].AddComponent<PlayerHandSlot>();

            gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - 1].GetComponent<PlayerHandSlot>()._slot = 1;
            // for back end deck
            Card card = gameManager.Deck.Draw();
            gameManager.Hand.Add(card);
    }
}
