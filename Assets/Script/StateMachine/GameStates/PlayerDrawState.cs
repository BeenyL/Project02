using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawState : BattleState
{
    bool _activated = false;
    SetupBattleGameState setupbattlegamestate;
    GameManager gameManager;

    public override void Enter()
    {
        setupbattlegamestate = GetComponent<SetupBattleGameState>();
        gameManager = FindObjectOfType<GameManager>();
        print("Enter: Player Draw State");

        if(gameManager.Deck.Count == 0)
        {
            refreshCards();
        }

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
        for(int i = 0; i < 5; i++)
        {
            if (gameManager.cardPosTransforms[i].childCount == 0 && gameManager.Deck.Count > 0) {
                // for front end deck
                gameManager.HandDeck[i] = gameManager.PhysicalDeck[gameManager.Deck.Count - 1];

                gameManager.PhysicalDeck[gameManager.Deck.Count - 1] = null;

                gameManager.HandDeck[i].transform.position = gameManager.cardPosTransforms[i].position;

                gameManager.HandDeck[i].transform.parent = gameManager.cardPosTransforms[i];

                gameManager.HandDeck[i].AddComponent<PlayerHandSlot>();

                gameManager.HandDeck[i].GetComponent<PlayerHandSlot>()._slot = i;


                // for back end deck
                Card card = gameManager.Deck.Draw();
                gameManager.Hand.AddtoHand(card, i);
            }
        }

    }

    private void refreshCards()
    {
        int count = gameManager.DiscardDeck.Count;
        for(int i = 0; i < count; i++)
        {
            gameManager.PhysicalDeck[i] = gameManager.FrontEndDiscardDeck[i];
            gameManager.FrontEndDiscardDeck[i] = null;
            //for front end deck
            gameManager.PhysicalDeck[i].transform.position = gameManager.deckPos.position;

            //for back end deck
            Card card = gameManager.DiscardDeck.GetCard(0);
            Debug.Log(card.Name);
            gameManager.Deck.Add(card);

            gameManager.DiscardDeck.Remove(0);

        }
        setupbattlegamestate.ShuffleDeckBackend();
        setupbattlegamestate.CreateDeckFrontend();
    }
}
