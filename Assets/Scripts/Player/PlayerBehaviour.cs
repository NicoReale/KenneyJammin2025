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

        health = new HealthComponent(100);
        attackBehaviour = new AttackBehaviour().Initialize(LeftAttackPoint,RightAttackPoint,TopRightAttackPoint,TopLeftAttackPoint, fireball, wave);
    }

    private void Start()
    {
        GameManager.Instance.player = this;
    }

    public void Attack(ATTACKANGLE side)
    {
        attackBehaviour.Attack(side);
    }


}
