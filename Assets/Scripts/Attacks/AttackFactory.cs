using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class AttackFactory<T>
{
    List<T> _currentStock;
    Func<T> _factoryMethod; //Create
    bool _isDynamic;
    Action<T> _turnOnCallback;
    Action<T> _turnOffCallback;


    public ObjectPool(Func<T> factroyMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factroyMethod;
        _isDynamic = isDynamic;

        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;
        _currentStock = new List<T>();

        for(var i = 0; i < initialStock; i++)
        {
            var o = _factoryMethod();
            _turnOffCallback(o);
            _currentStock.Add(o);
        }
    }

    /*public AttackFactory Initialize()
    {
        return this;
    }

    public IAttack GetAttack(ATTACKANGLE direction, Vector3 position, Quaternion rotation)
    {

        var attack = AttackPool<AttackFireball>.instance.GetPooledObject();
        if(attack != null)
        {
            attack.SetActive(true);
            attack.transform.position = position;
            attack.transform.rotation = rotation;

            var newAttack = attack.GetComponent<IAttack>();
            newAttack.Initialize();
        }

        return null;

    }*/



}
