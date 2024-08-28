using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnWave : Spawner
{
    [SerializeField] protected static EnemySpawnWave instance;
    [SerializeField] public static EnemySpawnWave Instance => instance;

    [SerializeField] protected float pointsWave;
    [SerializeField] public int currentWave = 1;
    [SerializeField] public int waveValue = 1;
    protected List<Transform> enemiestoSpawn = new List<Transform>();
    [SerializeField] protected int waveDuration;
    [SerializeField] protected float waveTimer;
    [SerializeField] protected float spawnInterval;
    [SerializeField] protected int count_wave = 0;
    [SerializeField] public int maxWave = 3;

    [SerializeField] protected float spawnTimer; //time when to enemy appear

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Start()
    {
        this.ResetWave();
        this.GenerateWave();
    }

    protected virtual void ResetWave()
    {
        currentWave = 1;
    }

    protected virtual void FixedUpdate()
    {
        this.SpawningWave();
    }

    protected virtual void GenerateWave()
    {

        waveValue = currentWave * 5;
        GenerateEnemies(waveValue);

        spawnInterval = waveDuration / enemiestoSpawn.Count; // thoi gian co dinh moi lan spawn enemy tu list
        waveTimer = waveDuration;

    }

    protected virtual void GenerateEnemies(int waveValue)
    {
        List<Transform> generatedEnemies = new List<Transform>();
        while (waveValue >= 0)
        {
            int randEnemy = Random.Range(0, prefabs.Count);
            int randEnemyCost = prefabs[randEnemy].GetComponent<EnemyCtrl>().EnemySO.cost;

            waveValue -= randEnemyCost;
            if (waveValue - randEnemyCost >= 0)
            {

                generatedEnemies.Add(prefabs[randEnemy]);


            }
            else if (waveValue - randEnemyCost < 0)
            {
                break;
            }
            enemiestoSpawn.Clear();
            //enemiestoSpawn = generatedEnemies;
            enemiestoSpawn.AddRange(generatedEnemies);
            count_wave = enemiestoSpawn.Count;

        }

    }

    protected virtual bool CheckWaveEnd()
    {
        if (EnemySpawner.Instance.PoolObjs.Count >= count_wave)
        {

            return true;
        }
        return false;
    }


    protected virtual void SpawningWave()
    {

        if (currentWave <= maxWave)
        {
            if (spawnTimer < 0)
            {
                if (enemiestoSpawn.Count > 0)
                {
                    Transform enemy = this.Spawn(enemiestoSpawn[0], EnemyShipManager.Instance.spawnPoints[Random.Range(0, 4)].position, Quaternion.identity);
                    enemy.GetComponent<BulletCtrl>();
                    enemy.gameObject.SetActive(true);

                    enemiestoSpawn.RemoveAt(0);
                    spawnTimer = 2;
                }
                else
                {
                    if (CheckWaveEnd())
                    {
                        spawnTimer = 5;
                        if(currentWave < maxWave) currentWave++;
                        Debug.Log("Wave: " + currentWave);
                        GenerateWave();


                    }

                }
            }
            else
            {

                spawnTimer -= Time.fixedDeltaTime;
                waveTimer -= Time.fixedDeltaTime;
            }
        }
        else
        {
            return;
        }
    }

}

