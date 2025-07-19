
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    EnemyBehaviour enemyBehaviour;
    [SerializeField]
    Transform LeftSpawnPoint, RightSpawnPoint;

    float Timer;

    public void SpawnEnemy()
    {
        var val = Random.value;
        if (val >= 0.51f)
        {
            Instantiate(enemyBehaviour, LeftSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.LEFT);
        }
        else
        {
            Instantiate(enemyBehaviour, RightSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.RIGHT);
        }
    }


    private void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0 )
        {
            Timer = Random.Range(1, 5);
            SpawnEnemy();
        }
    }
}
