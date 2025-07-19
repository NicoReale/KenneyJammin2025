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

    public void Attack(ATTACKANGLE side)
    {
        attackBehaviour.Attack(side);
    }


}
