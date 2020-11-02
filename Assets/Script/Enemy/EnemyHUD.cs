using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    [SerializeField] Slider enemyHealth;
    [SerializeField] Text enemyHealthText;
    [SerializeField] Text enemyText;
    [SerializeField] Enemy enemy;

    public void updateEnemyHealth()
    {
        enemyHealth.value = enemy._health;
        enemyHealthText.text = "HP: " + enemy._health.ToString();
    }
    public void setMaxHealth(int value)
    {
        enemyHealth.maxValue = value;
    }
    public void setEnemyText(string dialog)
    {
        enemyText.text = dialog;
    }
}
