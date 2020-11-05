using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 300;
    public int _health { get => health; set => health = value; }
    public virtual void TakeDamage(int value)
    {
        health -= value;
    }

    public virtual void Heal(int value)
    {

        health += value;
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }

}
