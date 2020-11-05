using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Slider HealthBar;
    [SerializeField] Slider ManaBar;
    [SerializeField] Slider ArmorBar;

    [SerializeField] Text HealthText;
    [SerializeField] Text ManaText;
    [SerializeField] Text ArmorText;
    [SerializeField] Text AttackText;

    [SerializeField] PlayerProperty playerprop;
    public void updateHealthBar()
    {
        HealthBar.value = playerprop._health;
        HealthText.text = "HP: " + playerprop._health.ToString();
    }

    public void updateManaBar()
    {
        ManaBar.value = playerprop._mana;
        ManaText.text = "MP: " + playerprop._mana.ToString();
    }

    public void updateArmorBar()
    {
        ArmorBar.value = playerprop._armor;
        ArmorText.text = "Armor: " + playerprop._armor.ToString();
    }

    public void updateAttack()
    {
        AttackText.text = "Atk: " + playerprop._attackboostVal.ToString();
    }

    public void setMaxHealth(int value)
    {
        HealthBar.maxValue = value;
    }

    public void setMaxMana(int value)
    {
        ManaBar.maxValue = value;
    }

    public void setMaxArmor(int value)
    {
        ArmorBar.maxValue = value;
    }
}
