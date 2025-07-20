using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    List<EnemyBehaviour> enemyPrefabs;
    [SerializeField]
    Transform LeftSpawnPoint, RightSpawnPoint, TopLeftSpawnPoint, TopRightSpawnPoint;

    EnemySpawner spawner;

    float Timer;

    List<EnemyBehaviour> waveOneEnemies;
    List<int> waveOneAmounts;

    List<EnemyBehaviour> waveTwoEnemies;
    List<int> waveTwoAmounts;
    List<EnemyBehaviour> waveEnemies;
    int currentWave = 0;

    public GameObject horizontalProj;
    float projTimer = 3;

    List<EnemyBehaviour> currentEnemies = new List<EnemyBehaviour>();
    private void Start()
    {

        Initialize();
        if(GameManager.Instance.currentLevel == 1)
        {
            GetLevelWaves(10,
            new List<List<int>> { 
                EntityData.LevelOneWaveOne.amount,
                EntityData.LevelOneWaveTwo.amount,
                EntityData.LevelOneWaveThree.amount,
                EntityData.LevelOneWaveFour.amount,
                EntityData.LevelOneWaveFive.amount,
                EntityData.LevelOneWaveSix.amount,
                EntityData.LevelOneWaveSeven.amount,
                EntityData.LevelOneWaveEight.amount,
                EntityData.LevelOneWaveNine.amount,
                EntityData.LevelOneWaveTen.amount
            });
        }
        if (GameManager.Instance.currentLevel == 2)
        {
            GetLevelWaves(2,
            new List<List<int>> { EntityData.waveOneLevelTwo.amount, EntityData.waveTwoLevelTwo.amount });
        }

    }
    private void Initialize()
    {
        spawner = new EnemySpawner();
        waveEnemies = new List<EnemyBehaviour> { enemyPrefabs[0], enemyPrefabs[1] };
    }

    public void GetLevelWaves(int waveAmount, List<List<int>> amountToSpawnPerWave)
    {
        for (int i = 0; i < waveAmount; i++)
        {
            spawner.DefineWaves(waveEnemies, amountToSpawnPerWave[i].ToList(), i);
        }
    }

    public void RemoveFromPool(EnemyBehaviour enemyToRemove)
    {
        currentEnemies.Remove(enemyToRemove);
    }

    public void SpawnEnemy()
    {

        if(currentEnemies.Count == 0 && currentWave >= spawner.GetLevelLength())
        {
            GameManager.Instance.ChangeScene(2);
            return;
        }

        EnemyBehaviour enemyInstance = null;
        var enemy = spawner.SpawnEnemies(waveEnemies, currentWave);
        if (enemy == null)
        {
            currentWave++;
            return;
        }
        if (enemy.GetComponent<EnemyMelee>() != null)
        {
            var val = UnityEngine.Random.value;
            if (val >= 0.51f)
            {
                enemyInstance = Instantiate(enemy, LeftSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.LEFT, RemoveFromPool);
            }
            else
            {
                enemyInstance = Instantiate(enemy, RightSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.RIGHT, RemoveFromPool);
            }
        }
        else if (enemy.GetComponent<EnemyFlyingBasic>() != null)
        {
            var val = UnityEngine.Random.value;
            if (val >= 0.51f)
            {
                enemyInstance = Instantiate(enemy, TopLeftSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.TOPLEFT, RemoveFromPool);
            }
            else
            {
                enemyInstance = Instantiate(enemy, TopRightSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.TOPRIGHT, RemoveFromPool);
            }
        }


        if (enemyInstance != null)
        {
            currentEnemies.Add(enemyInstance); 
        }

    }


    private void Update()
    {
        Timer -= Time.deltaTime;
        projTimer -= Time.deltaTime;
        if(Timer <= 0 )
        {
            Timer = UnityEngine.Random.Range(1, 3);
            SpawnEnemy();
        }
        if(projTimer <= 0 )
        {
            var rndSide = UnityEngine.Random.Range(0, 2);
            if (rndSide >= 0.5f)
            {
                var proj = Instantiate(horizontalProj, RightSpawnPoint.transform.position, Quaternion.identity);
                proj.GetComponent<HorizontalProjectile>().SetDirection(new Vector2(-1,0));
            }
            else
            {
                var proj = Instantiate(horizontalProj, LeftSpawnPoint.transform.position, Quaternion.identity);
                proj.GetComponent<HorizontalProjectile>().SetDirection(new Vector2(1, 0));
            }
            projTimer = 7;
        }
    }
}


public class EnemySpawner
{
    List<Dictionary<EnemyBehaviour, int>> enemySpawnAmount = new List<Dictionary<EnemyBehaviour, int>>();

    public void DefineWaves(List<EnemyBehaviour> enemiesToSpawn, List<int> spawnAmount, int wave)
    {
        while (enemySpawnAmount.Count <= wave)
        {
            enemySpawnAmount.Add(new Dictionary<EnemyBehaviour, int>());
        }

        // Now safe to access by index
        for (int i = 0; i < spawnAmount.Count; i++)
        {
            if (enemiesToSpawn[i] == null)
                break;

            enemySpawnAmount[wave][enemiesToSpawn[i]] = spawnAmount[i];
        }
    }

    public EnemyBehaviour SpawnEnemies(List<EnemyBehaviour> enemiesToSpawn, int wave)
    {
        var spawnChoices = new List<EnemyBehaviour>();

        for (int j = 0; j < enemiesToSpawn.Count; j++)
        {
            if (enemySpawnAmount[wave].TryGetValue(enemiesToSpawn[j], out int amount) && amount > 0)
            {
                spawnChoices.Add(enemiesToSpawn[j]);
            }
        }
        if (spawnChoices.Count == 0)
            return null;

        int index = UnityEngine.Random.Range(0, spawnChoices.Count);
        EnemyBehaviour selected = spawnChoices[index];

        enemySpawnAmount[wave][selected]--;

        return selected;
    }

    public int GetLevelLength()
    {
        return enemySpawnAmount.Count;
    }
}
