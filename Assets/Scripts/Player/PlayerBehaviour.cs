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
    Transform LeftAttackPoint, RightAttackPoint, TopRightAttackPoint, TopLeftAttackPoint;
    [SerializeField]
    AttackFireball fireball;
    [SerializeField]
    AttackWave wave;



    private void Awake()
    {
        GameManager.Instance.player = this;
        health = new HealthComponent();
        health.SetHealth(EntityData.playerData.health);
        attackBehaviour = new AttackBehaviour().Initialize(LeftAttackPoint,RightAttackPoint,TopRightAttackPoint,TopLeftAttackPoint, fireball, wave);
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            attackBehaviour.Attack(ATTACKANGLE.LEFT);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            attackBehaviour.Attack(ATTACKANGLE.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackBehaviour.Attack(ATTACKANGLE.TOPLEFT);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackBehaviour.Attack(ATTACKANGLE.TOPRIGHT);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            attackBehaviour.Attack(ATTACKANGLE.TOP);
        }
    }

    public void Attack(ATTACKANGLE side)
    {
        attackBehaviour.Attack(side);
    }


}
