using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyProjectile : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Suponiendo que el jugador tiene un script con método TakeDamage()
            EntityData.playerData.health -= damage;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

