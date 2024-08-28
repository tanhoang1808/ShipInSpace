using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
   
    [SerializeField] protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    

   
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Excced EnemySpawmer instance");
            
        }
        EnemySpawner.instance = this;
    }


    public virtual Transform Spawn(EnemyCode enemyCode)
    {
        return this.Spawn(enemyCode.ToString(), Vector3.zero, Quaternion.identity);
    }

    public virtual Transform Spawn(EnemyCtrl enemyCtrl,Vector3 pos,Quaternion rot)
    {
        return this.Spawn(enemyCtrl.name.ToString(), pos, rot);
    }


}
