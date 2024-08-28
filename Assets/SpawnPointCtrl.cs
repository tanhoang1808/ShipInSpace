using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCtrl : HoangMonoBehaviour
{
    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    [SerializeField] public EnemySpawnPoint EnemySpawnPoint => enemySpawnPoint;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnPoint();
    }

    protected virtual void LoadEnemySpawnPoint()
    {
        this.enemySpawnPoint = GetComponentInChildren<EnemySpawnPoint>();

    }



}
