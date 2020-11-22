using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCard : Card
{
    public Sprite Graphic { get; private set; }
    public CardEffect PlayEffect { get; private set; }
    public Type type { get; }
    public Effects effect { get; }
    public int effectValue { get; }
    public AudioClip sound { get; }

    public AbilityCard(AbilityCardData Data)
    {
        Name = Data.Name;
        Cost = Data.Cost;
        Graphic = Data.Graphic;
        PlayEffect = Data.playEffect;
        type = Data.CardType;
        effect = Data.Effect;
        effectValue = Data.Effect_Value;
        sound = Data.Sound;
    }

    public override void Play()
    {
        PlayEffect.Activate();
    }
}
