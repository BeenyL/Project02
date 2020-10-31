using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 300;
    public int _health => health;
    public void TakeDamage(int value)
    {
        health -= value;
    }

    public void Heal(int value)
    {

        health += value;
    }

    protected virtual void Die()
    {

    }

}
