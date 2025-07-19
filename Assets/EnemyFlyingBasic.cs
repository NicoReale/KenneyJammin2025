using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingBasic : EnemyBehaviour
{
    public override EnemyBehaviour Initialize(ATTACKANGLE side)
    {
        health.SetHealth(EntityData.EnemyBasicFlying.health);
        if (side == ATTACKANGLE.TOPRIGHT)
        {
            sr.flipX = true;
        }

        return this;
    }
}
