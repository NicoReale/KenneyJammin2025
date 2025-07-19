using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent
{

    int health;
    public Action DeadCallback;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Damage:{damage} | HP: {health}");
        if(health <= 0)
        {
            DeadCallback();
        }
    }

    public void SetHealth(int health)
    {
        if(this.health >= health)
        {
            return;
        }
        this.health = health;
    }
}
