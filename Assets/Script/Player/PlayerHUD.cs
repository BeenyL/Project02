using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Slider HealthBar;
    [SerializeField] Slider ManaBar;

    [SerializeField] Text HealthText;
    [SerializeField] Text ManaText;

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

    public void setMaxHealth(int value)
    {
        HealthBar.maxValue = value;
    }

    public void setMaxMana(int value)
    {
        ManaBar.maxValue = value;
    }

}
