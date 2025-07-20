using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalProjectile : MonoBehaviour
{
    private Vector2 direction;
    public float speed = 5f;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerBehaviour>();

        if (player != null)
        {
            GameManager.Instance.player.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
