using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackBehaviour
{
    [SerializeField]
    Transform LeftAttackPoint, RightAttackPoint, TopRightAttackPoint, TopLeftAttackPoint;
    AttackFireball fireball;
    AttackWave wave;

    public delegate IAttack Shoot(IAttack projectile, Vector3 position, Quaternion rotation);
    public event Shoot ShootAttack;

    public AttackBehaviour Initialize(Transform leftAttack, Transform rightAttck, Transform topRightAttack, Transform topLeftAttack, AttackFireball fireball, AttackWave wave)
    {
        LeftAttackPoint = leftAttack;
        RightAttackPoint = rightAttck;
        TopRightAttackPoint = topRightAttack;
        TopLeftAttackPoint = topLeftAttack;
        this.fireball = fireball;
        this.wave = wave;
        return this;
    }

    public void Attack(ATTACKANGLE side)
    {
        switch (side)
        {
            case ATTACKANGLE.LEFT:
                Debug.Log("Attack Left");
                ShootAttack(fireball, LeftAttackPoint.transform.position, LeftAttackPoint.transform.rotation);
                return;
            case ATTACKANGLE.RIGHT:
                Debug.Log("Attack Right");
                ShootAttack(fireball, RightAttackPoint.transform.position, RightAttackPoint.transform.rotation);
                return;
            case ATTACKANGLE.TOP:
                return;
            case ATTACKANGLE.TOPRIGHT:
                ShootAttack(wave, TopRightAttackPoint.transform.position, TopRightAttackPoint.transform.rotation);
                return;
            case ATTACKANGLE.TOPLEFT:
                ShootAttack(wave, TopLeftAttackPoint.transform.position, TopLeftAttackPoint.transform.rotation);
                return;
        }
    }
}
