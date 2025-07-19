using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireball : PlayerAttack
{
    float speed;

    public override void Update()
    {
        base.Update();

        if (gameObject.activeInHierarchy)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }


    public override void Initialize()
    {
        base.Initialize();
        speed = 4f;
    }


}
