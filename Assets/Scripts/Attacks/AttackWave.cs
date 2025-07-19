using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWave : PlayerAttack
{
    float speed;

    public override void Initialize()
    {
        base.Initialize();
        damage = EntityData.waveAttackData.damage;
        speed = EntityData.waveAttackData.speed * EntityData.gameData.currentGameSpeed;
    }


    public override void Update()
    {
        base.Update();
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
