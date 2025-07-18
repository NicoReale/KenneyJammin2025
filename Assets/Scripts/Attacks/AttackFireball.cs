using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireball : MonoBehaviour, IAttack
{
    float speed = 4f;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
        if(enemy != null)
        {
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        
    }

    public GameObject Self()
    {
        return gameObject;
    }
}
