using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    ATTACKANGLE direction;
    int dir = -1;
    float speed = 4f;
    public EnemyBehaviour Initialize(ATTACKANGLE direccion)
    {
        if(direccion == ATTACKANGLE.RIGHT)
        {
            dir = 1;
        }
        return this;
    }

    void Update()
    {
        transform.position += (Vector3.left * dir) * speed * Time.deltaTime;
    }
}
