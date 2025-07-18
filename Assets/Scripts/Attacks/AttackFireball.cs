using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireball : MonoBehaviour
{
    int direction = 1;
    float speed = 4f;
    public AttackFireball Initialize(int direction)
    {
        this.direction = direction;
        return this;
    }

    void Update()
    {
        transform.position += (Vector3.left * direction) * speed * Time.deltaTime;
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
}
