using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] int CurrentLevel;
    [SerializeField] int Health;
    [SerializeField] int Mana;
    [SerializeField] int Armor;
    [SerializeField] int Attack;
    public static SaveManager instance;
    public int currentLevel { get => CurrentLevel; set => CurrentLevel = value; }
    public int currentHealth { get => Health; set => Health = value; }
    public int currentMana { get => Mana; set => Mana = value; }
    public int currentArmor { get => Armor; set => Armor = value; }
    public int currentAttack { get => Attack; set => Attack = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setData(SaveData savedata)
    {
        CurrentLevel = savedata.CurrentLevel;
        Health = savedata.Health;
        Mana = savedata.Mana;
        Armor = savedata.Armor;
        Attack = savedata.Attack;
    }
}
