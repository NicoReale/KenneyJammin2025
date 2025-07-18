using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class AttackPool<T> : MonoBehaviour where T : PlayerAttack
{
    List<T> _currentStock;
    Func<T> _factoryMethod; //Create
    bool _isDynamic;
    Action<T> _turnOnCallback;
    Action<T> _turnOffCallback;


    public AttackPool(Func<T> factroyMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factroyMethod;
        _isDynamic = isDynamic;

        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;
        _currentStock = new List<T>();

        for (var i = 0; i < initialStock; i++)
        {
            var o = _factoryMethod();
            _turnOffCallback(o);
            _currentStock.Add(o);
        }
    }
}
