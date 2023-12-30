using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected InputSystemControl inputActions;
    protected bool canAttack = true;
    protected float attackCooldown;
    protected float attackTimer = 0f;


    protected virtual void Awake()
    {
        inputActions = new InputSystemControl();
    }

    protected virtual void OnEnable()
    {
        inputActions.Enable();
    }

    protected virtual void Start()
    {
        inputActions.Attack.Hit.started += _ => Attack();
    }

    protected virtual void Update()
    {
        WeaponFlip();
        AttackCooldown();
    }

    public virtual void Attack() { }

    public virtual void WeaponFlip() { }

    protected void AttackCooldown()
    {
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                canAttack = true;
                attackTimer = 0f;
            }
        }

    }
}
