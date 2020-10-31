using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    [SerializeField] Slider enemyHealth;
    [SerializeField] Text enemyHealthText;
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

}
