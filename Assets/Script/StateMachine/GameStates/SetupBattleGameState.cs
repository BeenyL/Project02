using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBattleGameState : BattleState
{
    GameManager gameManager;

    bool _activated = false;

    public override void Enter()
    {
        print("Enter: Setup State");
        gameManager = FindObjectOfType<GameManager>();
        CreateDeckBackend();
        ShuffleDeckBackend();
        CreateDeckFrontend();

        _activated = true;
    }

    public override void Tick()
    {
        if (_activated == true)
            StateMachine.ChangeState<PlayerDrawState>();
            DrawCard();
    }

    public override void Exit()
    {
        print("Exit: Setup State");
        _activated = false;
    }

    void CreateDeckBackend()
    {
        foreach (AbilityCardData cardData in gameManager.DeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(cardData);

            gameManager.Deck.Add(newAbilityCard);
        }
    }

    void CreateDeckFrontend()
    {
        for (int i = 0; i < gameManager.PhysicalDeck.Length; i++)
        {
            AbilityCardView abilityCardView = gameManager.PhysicalDeck[i].GetComponent<AbilityCardView>();
            AbilityCard abilityCard = (AbilityCard)gameManager.Deck.GetCard(i);
            abilityCardView.Display(abilityCard);
        }
    }

    void ShuffleDeckBackend()
    {
        gameManager.Deck.Shuffle();

    }

    void DrawCard()
    {
            for (int i = 0; i < 5; i++)
            {
            // for front end deck
                gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - i - 1].transform.position = gameManager.cardPosTransforms[i].position;

                gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - i - 1].AddComponent<PlayerHandSlot>();

                gameManager.PhysicalDeck[gameManager.PhysicalDeck.Length - i - 1].GetComponent<PlayerHandSlot>()._slot = i;
            // for back end deck
                Card card = gameManager.Deck.Draw();
                Debug.Log(card.Name);
            }
    }
}
