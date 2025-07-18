using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireball : PlayerAttack
{
    float speed;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }


    public override void Initialize()
    {
        speed = 4f;
    }


}
