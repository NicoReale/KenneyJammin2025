using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent
{

    float health;
    public Action DeadCallback;

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Lerp(health, health - damage, Time.deltaTime);
        Debug.Log($"Damage:{damage} | HP: {health}");
        if(health <= 0)
        {
            DeadCallback();
        }
    }


    public void SetHealth(float health)
    {
        if(this.health >= health)
        {
            return;
        }
        this.health = health;
    }
}
