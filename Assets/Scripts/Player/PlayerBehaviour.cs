using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{


    [SerializeField]
    HealthComponent health;
    AttackBehaviour attackBehaviour;
   // AttackFactory attackFactory;
    float mana = 100;

    [SerializeField]
    Transform LeftAttackPoint, RightAttackPoint, TopRightAttackPoint, TopLeftAttackPoint;
    [SerializeField]
    AttackFireball fireball;
    [SerializeField]
    AttackWave wave;

    private void Awake()
    {
        health = new HealthComponent(100);
       // attackFactory = new AttackFactory().Initialize();
        attackBehaviour = new AttackBehaviour().Initialize(LeftAttackPoint,RightAttackPoint,TopRightAttackPoint,TopLeftAttackPoint, fireball, wave);

        //attackBehaviour.ShootAttack += attackFactory.GetAttack;
    }

    public void Attack(ATTACKANGLE side)
    {
        attackBehaviour.Attack(side);
    }


}
