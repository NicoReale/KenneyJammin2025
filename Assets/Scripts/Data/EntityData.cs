using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public float health;
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
    public float health;
    public float speed;
    public int damage;
    public float attackTimer;
}

public class Wave
{
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
        speed = 2f,
        damage = 5,
        attackTimer = 2
    };
    public static BasicEnemy EnemyBasicFlying = new BasicEnemy
    {
        health = 20,
        speed = 3f,
        damage = 20,
        attackTimer = 4
    };
    public static Wave LevelOneWaveOne = new Wave
    {
        amount = new List<int> { 4 , 0 }
    };
    public static Wave LevelOneWaveTwo = new Wave
    {
        amount = new List<int> { 8, 5 }
    };
    public static Wave LevelOneWaveThree = new Wave
    {
        amount = new List<int> { 16, 10 }
    };
    public static Wave LevelOneWaveFour = new Wave
    {
        amount = new List<int> { 20, 15 }
    };
    public static Wave LevelOneWaveFive = new Wave
    {
        amount = new List<int> { 25, 20 }
    };
    public static Wave LevelOneWaveSix = new Wave
    {
        amount = new List<int> { 30, 20 }
    };
    public static Wave LevelOneWaveSeven = new Wave
    {
        amount = new List<int> { 40, 25 }
    };
    public static Wave LevelOneWaveEight = new Wave
    {
        amount = new List<int> { 40, 30 }
    };
    public static Wave LevelOneWaveNine = new Wave
    {
        amount = new List<int> { 45, 40 }
    };
    public static Wave LevelOneWaveTen = new Wave
    {
        amount = new List<int> { 50, 50 }
    };


    public static Wave waveOneLevelTwo = new Wave
    {
        amount = new List<int> { 7, 4 }
    };
    public static Wave waveTwoLevelTwo = new Wave
    {
        amount = new List<int> { 15, 15 }
    };

}

