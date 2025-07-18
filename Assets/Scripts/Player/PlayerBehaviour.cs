using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform LeftAttackPoint, RightAttackPoint;
    [SerializeField]
    AttackFireball fireball;


    float mana = 100;
    public void Attack(ATTACKANGLE side)
    {
        if (mana < 1) return;
        switch(side)
        {
            case ATTACKANGLE.LEFT:
                Debug.Log("Attack Left");
                Instantiate(fireball, LeftAttackPoint.transform.position, Quaternion.identity).Initialize(1);
                mana -= 30;
                return;
            case ATTACKANGLE.RIGHT:
                Debug.Log("Attack Right");
                Instantiate(fireball, RightAttackPoint.transform.position, Quaternion.identity).Initialize(-1);
                mana -= 30;
                return;
            case ATTACKANGLE.TOP:
                return;
            case ATTACKANGLE.TOPRIGHT:
                return;
            case ATTACKANGLE.TOPLEFT:
                return;
        }
    }

    public void Update()
    {
        mana += 5 * Time.deltaTime;
        if(Mathf.RoundToInt(mana) % 10 == 0 )
        {
            Debug.Log(mana);
        }
    }

}
