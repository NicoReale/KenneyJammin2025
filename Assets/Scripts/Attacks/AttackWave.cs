using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWave : PlayerAttack
{
    int speed;

    public override void Initialize()
    {
        base.Initialize();
        speed = 5;
    }


    void Update()
    {
        base.Update();
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
