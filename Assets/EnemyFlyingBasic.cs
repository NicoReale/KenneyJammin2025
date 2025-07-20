using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingBasic : EnemyBehaviour
{
    float timer = EntityData.EnemyBasicFlying.attackTimer;
    bool wait = true;
    float distance = 0;
    public override void Attack(float time)
    {
        timer -= time;
        if (timer <= 0)
        {
            isSearching = false;
            stop = false;
            animator.SetTrigger("Attack");
            if (Vector3.Distance(transform.position, enemyTarget.transform.position) <= 0.1f)
            {
                stop = true;
                EndAttack();
            }
        }

    }
    public void EndAttack()
    {
        animator.SetBool("Explode", true);
        AttackForm -= Attack;
        DamagePlayer();
        TakeDamage(100);
    }

    public override void Died()
    {
        OnDied.Invoke(this);
        Destroy(gameObject);
    }

    public override EnemyBehaviour Initialize(ATTACKANGLE side, Action<EnemyBehaviour> onDied)
    {
        base.Initialize(side, onDied);
        health.SetHealth(EntityData.EnemyBasicFlying.health);
        if (side == ATTACKANGLE.TOPRIGHT)
        {
            sr.flipX = true;
        }

        return this;
    }

    protected override int Damage() => EntityData.EnemyBasicFlying.damage;
}
