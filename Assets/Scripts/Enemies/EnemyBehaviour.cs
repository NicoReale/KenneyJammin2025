using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    int direction = 1;
    float speed = 4f;
    public EnemyBehaviour Initialize(int direction)
    {
        this.direction = direction;
        return this;
    }

    void Update()
    {
        transform.position += (Vector3.left * direction) * speed * Time.deltaTime;
    }
}
