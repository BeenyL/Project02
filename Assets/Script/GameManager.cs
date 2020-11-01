using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // front end
    [SerializeField] Transform[] _cardPosTransforms;
    public Transform[] cardPosTransforms => _cardPosTransforms;

    [SerializeField] Transform _selectedCardPos;
    public Transform selectedCardPos => _selectedCardPos;

    [SerializeField] GameObject[] _physicalDeck;
    public GameObject[] PhysicalDeck => _physicalDeck;

    // back end
    [SerializeField] List<AbilityCardData> _deckConfig;
    public List<AbilityCardData> DeckConfig => _deckConfig;

    Deck<Card> _hand = new Deck<Card>();
    public Deck<Card> Hand => _hand;

    Deck<Card> _deck = new Deck<Card>();
    public Deck<Card> Deck => _deck;
}
