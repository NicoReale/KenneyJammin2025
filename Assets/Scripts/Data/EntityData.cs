using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public int health;
    public string name;
}
public class Fireball
{
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

public class EntityData
{
    public static GameData gameData = new GameData 
    {
        defaultGameSpeed = 1f,
        currentGameSpeed = 1
    };
    public static Fireball fireballData = new Fireball
    {
        speed = 4
    };
    public static PlayerData playerData = new PlayerData
    {
        health = 50,
        name = "name"
    };
    public static BasicEnemy EnemyMelee = new BasicEnemy
    {
        health = 50,
        speed = 0.2f
    };
}

