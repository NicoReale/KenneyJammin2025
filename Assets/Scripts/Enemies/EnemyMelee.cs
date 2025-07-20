using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBehaviour
{
    float attackTimer = EntityData.EnemyMelee.attackTimer;
    public override void Attack(float time)
    {
        attackTimer -= time;
        if (attackTimer < 0)
        {
            animator.SetTrigger("Attack");
            attackTimer = EntityData.EnemyMelee.attackTimer;
        }
    }

    public override void Died()
    {
        OnDied.Invoke(this);
        AttackForm -= Attack;
        Destroy(gameObject);
    }

    public override EnemyBehaviour Initialize(ATTACKANGLE side, Action<EnemyBehaviour> onDied)
    {
        base.Initialize(side, onDied);
        health.SetHealth(EntityData.EnemyMelee.health);
        if (side == ATTACKANGLE.RIGHT)
        {
            sr.flipX = true;
        }

        return this;
    }

    protected override int Damage() => EntityData.EnemyMelee.damage;
}
