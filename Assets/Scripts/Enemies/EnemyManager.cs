using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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

    List<List<EnemyBehaviour>> waveEnemies;
    int currentWave = 0;

    private void Start()
    {
        Initialize();


    }
    private void Initialize()
    {
        spawner = new EnemySpawner();
        waveEnemies = new List<List<EnemyBehaviour>>();
        waveOneEnemies = new List<EnemyBehaviour> { enemyPrefabs[0] };
        waveOneAmounts = new List<int> { 5 };

        waveTwoEnemies = new List<EnemyBehaviour> { enemyPrefabs[0], enemyPrefabs[1] };
        waveTwoAmounts = new List<int> { 10, 5 };

        spawner.DefineWaves(waveOneEnemies, waveOneAmounts, 0);
        spawner.DefineWaves(waveTwoEnemies, waveTwoAmounts, 1);
        waveEnemies.Add(waveOneEnemies);
        waveEnemies.Add(waveTwoEnemies);
    }
    public List<EnemyBehaviour> GetNextWave(int wave)
    {
        if (wave < 0 || wave >= waveEnemies.Count) { return null; }
        return waveEnemies[wave];
    }

    public void SpawnEnemy()
    {
        if(GetNextWave(currentWave) == null)
        {
            Debug.Log("Level ended");
            return;
        }
        var enemy = spawner.SpawnEnemies(GetNextWave(currentWave), currentWave);

        if (enemy == null)
        {
            currentWave++;
            return;
        }
        if(enemy.GetComponent<EnemyMelee>() != null)
        {
            var val = UnityEngine.Random.value;
            if (val >= 0.51f)
            {
                Instantiate(enemy, LeftSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.LEFT);
            }
            else
            {
                Instantiate(enemy, RightSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.RIGHT);
            }
        }
        else if (enemy.GetComponent<EnemyFlyingBasic>() != null)
        {
            var val = UnityEngine.Random.value;
            if (val >= 0.51f)
            {
                Instantiate(enemy, TopLeftSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.TOPLEFT);
            }
            else
            {
                Instantiate(enemy, TopRightSpawnPoint.transform.position, Quaternion.identity).Initialize(ATTACKANGLE.TOPRIGHT);
            }
        }
    }


    private void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0 )
        {
            Timer = UnityEngine.Random.Range(1, 3);
            SpawnEnemy();
        }
    }
}


public class EnemySpawner
{
    List<Dictionary<EnemyBehaviour, int>> enemySpawnAmount = new List<Dictionary<EnemyBehaviour, int>>();

    public void DefineWaves(List<EnemyBehaviour> enemiesToSpawn, List<int> spawnAmount, int Wave)
    {
        enemySpawnAmount.Add(new Dictionary<EnemyBehaviour, int>());
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            enemySpawnAmount[Wave].Add(enemiesToSpawn[i], spawnAmount[i]);
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
}
