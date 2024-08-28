using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowPath : HoangMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected EnemyCtrl EnemyCtrl => enemyCtrl;
    [SerializeField] public static int index = 0;

    [SerializeField] protected float speed = 0.02f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
    }

    protected virtual void FixedUpdate()
    {
        this.Follow();
    }

    protected virtual void Follow()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, Vector3.down, speed * Time.fixedDeltaTime );
       
    }

}
