using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBehaviour
{

    public override EnemyBehaviour Initialize(ATTACKANGLE side)
    {
        health.SetHealth(EntityData.EnemyMelee.health);
        if (side == ATTACKANGLE.RIGHT)
        {
            sr.flipX = true;
        }

        return this;
    }

}
