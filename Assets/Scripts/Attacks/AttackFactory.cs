using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFactory
{
    public AttackFactory Initialize()
    {
        return this;
    }

    public IAttack GetAttack(IAttack projectile, Vector3 position, Quaternion rotation)
    {

        var attack = GameManager.Instantiate(projectile.Self(), position, rotation);

        if(attack.GetComponent<AttackFireball>() != null )
        {
            var newAttack = attack.GetComponent<AttackFireball>();
            newAttack.Initialize();
            return newAttack;
        }

        if(attack.GetComponent<AttackWave>() != null)
        {
            var newAttack = attack.GetComponent<AttackWave>();
            newAttack.Initialize();
            return newAttack;
        }



        return null;
    }
}
