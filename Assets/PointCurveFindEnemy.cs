using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCurveFindEnemy : MonoBehaviour
{
    [SerializeField] protected EnemyCtrl[] enemyPos;
    [SerializeField] protected float minDistance = 200f;
    [SerializeField] protected Transform nearstEnemy;


    protected virtual void Update()
    {
        this.CheckNearstEnemy();
    }

    public virtual Transform CheckNearstEnemy()
    {
        enemyPos = Transform.FindObjectsOfType<EnemyCtrl>();
        for(int i = 0; i < enemyPos.Length;i++)
        {
            if(Vector3.Distance(this.transform.position,enemyPos[i].transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(this.transform.position, enemyPos[i].transform.position);
                this.nearstEnemy = enemyPos[i].transform;
            }

        }
        minDistance = 100f;
        return this.nearstEnemy;
    }

    public virtual void GetRightPos()
    {
        this.transform.position = CheckNearstEnemy().position;
    }

}
