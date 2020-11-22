using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDrawState : BattleState
{
    bool _activated = false;
    SetupBattleGameState setupbattlegamestate;
    GameManager gameManager;
    PlayerProperty playerprop;
    [SerializeField] AudioSource drawaudio;
    [SerializeField] AudioSource turnaudio;
    [SerializeField] AudioClip Draw_Card;
    [SerializeField] AudioClip playerTurn;
    const string DrawState = "Draw";

    public override void Enter()
    {
        playerprop = FindObjectOfType<PlayerProperty>();
        setupbattlegamestate = GetComponent<SetupBattleGameState>();
        gameManager = FindObjectOfType<GameManager>();

        if(gameManager.Deck.Count == 0)
        {
            refreshCards();
        }
        if (!playerprop._isDead)
        {
            turnaudio.PlayOneShot(playerTurn);
            DrawCard();
            _activated = true;
        }
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
        _activated = false;
    }

    public void DrawCard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (gameManager.cardPosTransforms[i].childCount == 0 && gameManager.Deck.Count > 0) {
                // for front end deck
                gameManager.HandDeck[i] = gameManager.PhysicalDeck[gameManager.Deck.Count - 1];

                gameManager.PhysicalDeck[gameManager.Deck.Count - 1] = null;

                gameManager.HandDeck[i].transform.position = gameManager.cardStartPos.position;

                drawaudio.PlayOneShot(Draw_Card);

                Transform transform = gameManager.HandDeck[i].gameObject.transform;

                transform.DOMove(gameManager.cardPosTransforms[i].position, 1f, false);

                transform.DORotate(new Vector3(0, 360, 360), 1f, RotateMode.FastBeyond360);

                //gameManager.HandDeck[i].transform.position = gameManager.cardPosTransforms[i].position;
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
