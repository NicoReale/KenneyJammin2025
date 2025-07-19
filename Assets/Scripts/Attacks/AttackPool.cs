using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPool<T>
{
    List<T> _currentStock;
    Func<T> _factoryMethod; //Create
    bool _isDynamic;
    Action<T> _turnOnCallback;
    Action<T> _turnOffCallback;


    public AttackPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factoryMethod;
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

    public T GetObject()
    {
        var result = default(T);
        if( _currentStock.Count > 0 )
        {
            result = _currentStock[0];
            _currentStock.RemoveAt(0);
        }
        else if (_isDynamic )
        {
            result = _factoryMethod();
        }
        _turnOnCallback(result);
        return result;
    }

    public void ReturnObject(T obj)
    {
        _turnOffCallback(obj);
        _currentStock.Add(obj);
    }
}
