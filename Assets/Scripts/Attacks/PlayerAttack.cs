using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    public float ttl = 10;

    public virtual void Initialize()
    {
        gameObject.SetActive(true);
    }

    public GameObject Self() => gameObject;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();

        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0 )
        {
            gameObject.SetActive(false);
            ttl = 10;
        }
    }
}
