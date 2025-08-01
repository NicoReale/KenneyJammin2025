using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Pool;

[Serializable]
public class AttackBehaviour
{
    [SerializeField]
    Transform LeftAttackPoint, RightAttackPoint, TopRightAttackPoint, TopLeftAttackPoint;
    AttackFireball fireball;
    AttackWave wave;

    AttackFactory<AttackFireball> fireballFactory;
    AttackFactory<AttackWave> waveFactory;

    public delegate IAttack Shoot(ATTACKANGLE side, Vector3 position, Quaternion rotation);
    public event Shoot ShootFireball;
    public event Shoot ShootWave;


    public AttackBehaviour Initialize(Transform leftAttack, Transform rightAttck, Transform topRightAttack, Transform topLeftAttack, AttackFireball fireball, AttackWave wave)
    {


        LeftAttackPoint = leftAttack;
        RightAttackPoint = rightAttck;
        TopRightAttackPoint = topRightAttack;
        TopLeftAttackPoint = topLeftAttack;
        this.fireball = fireball;
        this.wave = wave;
        fireballFactory = new AttackFactory<AttackFireball>().Initialize(FireballFactoryMethod);
        waveFactory = new AttackFactory<AttackWave>().Initialize(WaveFactoryMethod);
        ShootFireball += fireballFactory.GetAttack;
        ShootWave += waveFactory.GetAttack;
        return this;
    }



    public ATTACKANGLE Attack(ATTACKANGLE side)
    {
        switch (side)
        {
            case ATTACKANGLE.LEFT:
                Debug.Log("Attack Left");
                ShootFireball(side, LeftAttackPoint.transform.position, LeftAttackPoint.transform.rotation);
                EntityData.playerData.Power += 2;
                return side;
            case ATTACKANGLE.RIGHT:
                Debug.Log("Attack Right");
                ShootFireball(side, RightAttackPoint.transform.position, RightAttackPoint.transform.rotation);
                EntityData.playerData.Power += 2;
                return side;
            case ATTACKANGLE.TOP:
                //throw new Exception("Not Implemented");
            case ATTACKANGLE.TOPRIGHT:
                ShootWave(side, TopRightAttackPoint.transform.position, TopRightAttackPoint.transform.rotation);
                EntityData.playerData.Power += 3.5f;
                return side;
            case ATTACKANGLE.TOPLEFT:
                ShootWave(side, TopLeftAttackPoint.transform.position, TopLeftAttackPoint.transform.rotation);
                EntityData.playerData.Power += 3.5f;
                return side;
            default: return side;
        }
    }

    AttackFireball FireballFactoryMethod()
    {
        return GameObject.Instantiate(fireball);
    }

    AttackWave WaveFactoryMethod()
    {
        return GameObject.Instantiate(wave);
    }
}
