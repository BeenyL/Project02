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

    [SerializeField] Transform _deckpos;
    public Transform deckPos => _deckpos;

    [SerializeField] Transform _discardTransform;
    public Transform discardTransform => _discardTransform;

    [SerializeField] GameObject[] _physicalDeck;
    public GameObject[] PhysicalDeck => _physicalDeck;

    [SerializeField] List<GameObject> _handDeck;
    public List<GameObject> HandDeck => _handDeck;

    [SerializeField] List<GameObject> _frontEndDiscardDeck;
    public List<GameObject> FrontEndDiscardDeck => _frontEndDiscardDeck;

    // back end
    [SerializeField] List<AbilityCardData> _deckConfig;
    public List<AbilityCardData> DeckConfig => _deckConfig;

    Deck<Card> _hand = new Deck<Card>();
    public Deck<Card> Hand => _hand;

    Deck<Card> _discardDeck = new Deck<Card>();
    public Deck<Card> DiscardDeck => _discardDeck;

    Deck<Card> _deck = new Deck<Card>();
    public Deck<Card> Deck => _deck;
}
