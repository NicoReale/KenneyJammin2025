using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
   
    void Awake()
    {
        GameManager.Instance.enemyTarget = this;
    }

}
