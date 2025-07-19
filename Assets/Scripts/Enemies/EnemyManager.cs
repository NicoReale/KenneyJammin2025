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
    List<EnemyBehaviour> waveEnemies;
    int currentWave = 0;

    private void Start()
    {

        Initialize();
        if(GameManager.Instance.currentLevel == 1)
        {
            GetLevelWaves(2,
            new List<List<int>> { EntityData.waveOneLevelOne.amount, EntityData.waveTwoLevelOne.amount });
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
        waveEnemies = new List<EnemyBehaviour> { enemyPrefabs[0], enemyPrefabs[1] }; // or however many enemies your level uses
    }

    public void GetLevelWaves(int waveAmount, List<List<int>> amountToSpawnPerWave)
    {
        for (int i = 0; i < waveAmount; i++)
        {
            spawner.DefineWaves(waveEnemies, amountToSpawnPerWave[i].ToList(), i);
        }
    }


    public void SpawnEnemy()
    {
        if(currentWave > waveEnemies.Count - 1)
        {
            GameManager.Instance.ChangeScene(2);
            return;
        }
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
}
