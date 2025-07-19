using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    public float ttl = 5;
    public delegate void despawn<T>(T obj);
    public event Action<PlayerAttack> OnDespawned;
    protected float currentTTL;
    public virtual void Initialize()
    {
        currentTTL = ttl;
        gameObject.SetActive(true);
    }

    public GameObject Self() => gameObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();

        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            Despawn();
        }
    }
    public virtual void Update()
    { 
        currentTTL -= Time.deltaTime;
        if (currentTTL <= 0)
        {
            Despawn();
        }
    }

    protected virtual void Despawn()
    {
        gameObject.SetActive(false);
        OnDespawned?.Invoke(this);
    }

    public virtual void ResetAttack()
    {
        currentTTL = ttl;
        // Reset any other properties specific to the attack type
    }
}
