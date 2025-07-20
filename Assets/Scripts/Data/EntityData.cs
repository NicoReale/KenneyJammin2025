using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public float health;
    public string name;
    public float Power;
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
    public float health;
    public float speed;
}

public class Wave
{
    public int waves;
    public List<int> amount;
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
    public static Wave waveOneLevelOne = new Wave
    {
        waves = 1,
        amount = new List<int> { 4 , 0 }
    };
    public static Wave waveTwoLevelOne = new Wave
    {
        waves = 1,
        amount = new List<int> { 8, 5 }
    };
    public static Wave waveThreeLevelOne = new Wave
    {
        waves = 1,
        amount = new List<int> { 10, 20 }
    };

    public static Wave waveOneLevelTwo = new Wave
    {
        waves = 1,
        amount = new List<int> { 7, 4 }
    };
    public static Wave waveTwoLevelTwo = new Wave
    {
        waves = 1,
        amount = new List<int> { 15, 15 }
    };

}

