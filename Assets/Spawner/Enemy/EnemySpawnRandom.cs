using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : Spawner
{
    [SerializeField] EnemySpawnRandomCtrl enemySpawnRandomCtrl;
    [SerializeField] public List<Transform> enemies;
    [SerializeField] public float enemyInWave;
   

   

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
       
    }

    protected virtual void LoadEnemyCtrl()
    {
        this.enemySpawnRandomCtrl = GetComponent<EnemySpawnRandomCtrl>();
    }


    
}
