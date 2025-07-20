using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{


    [SerializeField]
    HealthComponent health;
    AttackBehaviour attackBehaviour;

    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Transform LeftAttackPoint, RightAttackPoint, TopRightAttackPoint, TopLeftAttackPoint;
    [SerializeField]
    AttackFireball fireball;
    [SerializeField]
    AttackWave wave;

    private ATTACKANGLE currentAttack;

    bool attacking = false;

    private void Awake()
    {
        GameManager.Instance.player = this;
        health = new HealthComponent();
        health.SetHealth(EntityData.playerData.health);
        health.DeadCallback = onDead;
        attackBehaviour = new AttackBehaviour().Initialize(LeftAttackPoint,RightAttackPoint,TopRightAttackPoint,TopLeftAttackPoint, fireball, wave);
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

    public void onDead()
    {
        GameManager.Instance.ChangeScene(0);
    }

    private void Update()
    {
        if(!attacking)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.SetTrigger("fireballShoot");
                currentAttack = ATTACKANGLE.LEFT;
                attacking = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.SetTrigger("fireballShoot");
                currentAttack = ATTACKANGLE.RIGHT;
                attacking = true;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("slashShoot");
                currentAttack = ATTACKANGLE.TOPLEFT;
                attacking = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("slashShoot");
                currentAttack = ATTACKANGLE.TOPRIGHT;
                attacking = true;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentAttack = attackBehaviour.Attack(ATTACKANGLE.TOP);
            }
        }
    }

    public void Attack(ATTACKANGLE side)
    {
        attackBehaviour.Attack(side);
    }

    public void fireballShoot()
    {

        attackBehaviour.Attack(currentAttack);
        animator.ResetTrigger("fireballShoot");
    }

    public void slashShoot()
    {

        attackBehaviour.Attack(currentAttack);
        animator.ResetTrigger("slashShoot");
    }

    public void mirrorFreeze()
    {
        Debug.Log($"Started Attack :{currentAttack}");
        if (currentAttack == ATTACKANGLE.LEFT || currentAttack == ATTACKANGLE.TOPLEFT)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void endMirror()
    {
        Debug.Log("Ended Attack");
        attacking = false;
        spriteRenderer.flipX = false;
    }

}
