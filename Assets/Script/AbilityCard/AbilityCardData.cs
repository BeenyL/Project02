using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Item, Attack, Spell }
[CreateAssetMenu(fileName = "_AbilityCard", menuName = "CardData/AbilityCard")]
public class AbilityCardData : ScriptableObject
{
    [SerializeField] string _name = ". . .";
    public string Name => _name;

    [SerializeField] int _cost = 1;
    public int Cost => _cost;

    [SerializeField] Sprite _graphic = null;
    public Sprite Graphic => _graphic;

    [SerializeField] CardEffect _playEffect = null;
    public CardEffect playEffect => _playEffect;

    [SerializeField] Type _cardType;
    public Type CardType => _cardType;
}
