using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCard : Card
{
    public Sprite Graphic { get; private set; }
    public CardEffect PlayEffect { get; private set; }
    public AbilityCard(AbilityCardData Data)
    {
        Name = Data.Name;
        Cost = Data.Cost;
        Graphic = Data.Graphic;
        PlayEffect = Data.playEffect;
    }

    public override void Play()
    {
        
        Debug.Log("Playing " + Name + " on target");
        PlayEffect.Activate();
    }
}
