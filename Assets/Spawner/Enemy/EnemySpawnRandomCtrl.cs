using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandomCtrl : HoangMonoBehaviour
{
    [SerializeField] protected List<Transform> enemySpawnPoints;

    [SerializeField] protected static EnemySpawnRandomCtrl instance;
    [SerializeField] public static EnemySpawnRandomCtrl Instance => instance;

    [SerializeField] protected SpawnPointCtrl spawnPointCtrl;
    public SpawnPointCtrl SpawnPointCtrl => spawnPointCtrl;


    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Exceed enemyspawnrandomCtrl");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPointCtrl();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadSpawnPointCtrl()
    {
        this.spawnPointCtrl = Transform.FindObjectOfType<SpawnPointCtrl>();
    }

    protected virtual void LoadEnemySpawner()
    {
        this.enemySpawner = GetComponent<EnemySpawner>();
    }

    

    
}
