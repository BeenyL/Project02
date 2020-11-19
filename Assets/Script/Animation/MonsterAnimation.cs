using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterAnimation : MonoBehaviour
{
    public Animator _animator = null;
    [SerializeField] Enemy enemy;

    const string AttackState = "Attack";
    const string DieState = "Die";
    const string HurtState = "Hurt";
    const string IdleState = "Idle";

    private void Start()
    {
        enemy.GetComponent<Enemy>();
        _animator.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void Attack_Animation()
    {
        _animator.Play(AttackState);
    }

    public void Hurt_Animation()
    {
        _animator.Play(HurtState);
    }

    public void Die_Animation()
    {
        enemy._isSelected = false;
        _animator.Play(DieState);
    }

    public void Idle_Animation()
    {
        _animator.Play(IdleState);
    }
}
