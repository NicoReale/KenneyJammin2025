using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAttack : MonoBehaviour
{
    public float damage = 10f;
    public float duracion = 0.5f;
    public LayerMask EnemyLayer;


    private void Start()
    {
        damage = (EntityData.playerData.Power - 100) * 2;
        EntityData.playerData.health -= damage/10;
        Destroy(gameObject, duracion);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D collider2D1 = Physics2D.OverlapCircle(transform.position, 0.5f, EnemyLayer);
        if (collider2D1)
        {
            EntityData.EnemyBasicFlying.health -= damage;
            EntityData.EnemyMelee.health += damage;
        }
    }
}
