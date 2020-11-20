using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupBattleGameState : BattleState
{
    GameManager gameManager;
    SaveManager saveManager;
    [SerializeField] Text saveText;
    bool _activated = false;
    Enemy[] enemy;

    public override void Enter()
    {
        updateLevelText();
        print("Enter: Setup State");
        gameManager = FindObjectOfType<GameManager>();
        setupEnemies();
        CreateDeckBackend();
        ShuffleDeckBackend();
        CreateDeckFrontend();
        CreateHand();

        _activated = true;
    }

    public override void Tick()
    {
        if (_activated == true)
            StateMachine.ChangeState<PlayerDrawState>();
    }

    public override void Exit()
    {
        print("Exit: Setup State");
        _activated = false;
    }

    public void updateLevelText()
    {
        saveManager = FindObjectOfType<SaveManager>();
        saveText.text = "Current Level: " + (saveManager.currentLevel+1).ToString();
    }

    void setupEnemies()
    {
        saveManager = FindObjectOfType<SaveManager>();
        enemy = FindObjectsOfType<Enemy>();
        for (int i = 0; i < saveManager.currentLevel; i++) {
            foreach(Enemy e in enemy)
            {
                e.Respawn();
            }
        }
    }

    void CreateHand()
    {
        for(int i = 0; i < 5; i++)
        {
            AbilityCard fillerCard = new AbilityCard(gameManager.DeckConfig[0]);
            gameManager.Hand.Add(fillerCard);
        }
    }

    void CreateDeckBackend()
    {
        foreach (AbilityCardData cardData in gameManager.DeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(cardData);

            gameManager.Deck.Add(newAbilityCard);
        }
    }

    public void CreateDeckFrontend()
    {
        for (int i = 0; i < gameManager.PhysicalDeck.Length; i++)
        {
            if (gameManager.PhysicalDeck[i] != null)
            {
                AbilityCardView abilityCardView = gameManager.PhysicalDeck[i].GetComponent<AbilityCardView>();
                AbilityCard abilityCard = (AbilityCard)gameManager.Deck.GetCard(i);
                abilityCardView.Display(abilityCard);
            }
        }
    }

    public void ShuffleDeckBackend()
    {
        gameManager.Deck.Shuffle();

    }

}
