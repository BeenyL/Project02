using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int CurrentLevel;
    public int Health;
    public int Mana;
    public int Armor;
    public int Attack;

    public SaveData(SaveManager sm, PlayerProperty playerprop)
    {
        CurrentLevel = sm.currentLevel;
        Health = playerprop._health;
        Mana = playerprop._manaPool;
        Armor = playerprop._armor;
        Attack = playerprop._attackboostVal;
    }

}