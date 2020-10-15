using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    int _currentHealth = 10;
    
    public void Kill()
    {
        Debug.Log("Kill the creature");
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("took dmage. remaning health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Target()
    {
        Debug.Log("creature has been targeted");
    }
}
