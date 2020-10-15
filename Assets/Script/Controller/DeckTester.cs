using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();

    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    private void Start()
    {
        SetupAbilityDeck();
        /*
        // create some cards for the deck
        Debug.Log("Creatin Cards...");
        Card cardA = new Card("Sword");
        _testDeck.Add(cardA);
        Card cardB = new Card("Fireball");
        _testDeck.Add(cardB);
        Card cardC = new Card("Elixir");
        _testDeck.Add(cardC);
       
        // Draw a new card from the deck
        Card testCard = _testDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + testCard);

        // play the new card
        testCard.Play();
         */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTopCard();
        }
    }

    private void SetupAbilityDeck()
    {
        foreach(AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }

        _abilityDeck.Shuffle();
    }

    private void Draw()
    {
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);

        _abilityCardView.Display(newCard);
    }

    private void PrintPlayerHand()
    {
        for(int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayerTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();

        //TODO consider explanding Remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
