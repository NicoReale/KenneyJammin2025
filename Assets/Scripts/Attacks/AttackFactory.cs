using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFactory<T> where T : PlayerAttack, IAttack
{
    public AttackPool<T> _pool;

    public AttackFactory<T> Initialize(Func<T> factoryMethod, int initialStock = 10)
    {
        _pool = new AttackPool<T>(factoryMethod, TurnOnAttack, TurnOffAttack, initialStock, false);
        return this;
    }

    public T GetAttack(ATTACKANGLE direction, Vector3 position, Quaternion rotation)
    {

        var attack = _pool.GetObject();
        if(attack == null)
        {
            return null;
        }
        var attackGO = attack.gameObject;

        attackGO.transform.SetPositionAndRotation(position, rotation);
        var playerAttack = attackGO.GetComponent<PlayerAttack>();
        playerAttack.Initialize();
        playerAttack.OnDespawned += ReturnAttack;

        return attack;

    }

    private void TurnOnAttack(T attack)
    {
        if (attack == null)
            return;
        attack.ResetAttack();
    }

    private void TurnOffAttack(T attack)
    {
        attack.gameObject.SetActive(false);
        attack.OnDespawned -= ReturnAttack;
    }

    private void ReturnAttack(PlayerAttack attack)
    {
        if (attack is T typedAttack)
        {
            _pool.ReturnObject(typedAttack);
        }
    }


}
