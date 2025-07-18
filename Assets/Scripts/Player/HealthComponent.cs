using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent
{

    int health;

    public HealthComponent(int hp)
    {
        health = hp;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Damage:{damage} | HP: {damage}");
        if(health >= 0)
        {
            Debug.Log("Dead");
        }
    }
}
