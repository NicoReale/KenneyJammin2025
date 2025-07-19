using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float speed;
    PlayerBehaviour player;
    [SerializeField]
    SpriteRenderer sr;
    int dir = -1;

    private void Start()
    {
      
    }

    public EnemyBehaviour Initialize(ATTACKANGLE side)
    {
        player = GameManager.Instance.player;

        if(side == ATTACKANGLE.LEFT)
        {
            dir = 1;
        }
        else sr.flipX = true;

        return this;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > 1)
        {
            transform.position += (Vector3.right * dir) * (EntityData.EnemyMelee.speed * EntityData.gameData.currentGameSpeed) * Time.deltaTime;
        }
    }
}
