using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public int health;
    public string name;
}
public class BasicAttack
{
    public int damage;
    public int speed;
}

public class GameData
{
    public float defaultGameSpeed;
    public float currentGameSpeed;
}
public class BasicEnemy
{
    public int health;
    public float speed;
}

public class Waves
{
    //public
}

public class EntityData
{
    public static GameData gameData = new GameData 
    {
        defaultGameSpeed = 1f,
        currentGameSpeed = 1
    };
    public static BasicAttack fireballData = new BasicAttack
    {
        speed = 4,
        damage = 50
    };
    public static BasicAttack waveAttackData = new BasicAttack
    {
        speed = 7,
        damage = 20
    };

    public static PlayerData playerData = new PlayerData
    {
        health = 50,
        name = "name"
    };
    public static BasicEnemy EnemyMelee = new BasicEnemy
    {
        health = 50,
        speed = 2f
    };
    public static BasicEnemy EnemyBasicFlying = new BasicEnemy
    {
        health = 20,
        speed = 3f
    };

}

