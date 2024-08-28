using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    [SerializeField] protected float rad = 1f;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] public EnemyCtrl EnemyCtrl => enemyCtrl;
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.ObtainExp();

        EnemyCtrl.Instance.EnemySpawner.Despawn(transform.parent);
    }

    protected virtual void ObtainExp()
    {
      LevelManager.Instance.AddPlayerExp(EnemyCtrl.Instance.EnemySO.enemy_exp);
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
       Transform item = ItemDropSpawner.Instance.Drop(this.enemyCtrl.droplist[0], pos, rot);
        
        item.gameObject.SetActive(true);
    }



    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetRadius(rad);
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.setHPMax();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected override void ResetRadius(float rad)
    {
        this.sphereCollider.radius = rad;
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        enemyCtrl = Transform.FindObjectOfType<EnemyCtrl>();
    }

    protected override void setHPMax()
    {
        this.hpMax = enemyCtrl.EnemySO.hpMax;
    }



    protected virtual void OnDeadFX()
    {
        string fxName = this.GetDeadFXName();
        Vector3 pos = transform.parent.position;
        Quaternion rot = transform.rotation;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, pos, rot);

        EnemyCtrl.Instance.AudioCtrl.ExplodeSoundFX();
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetDeadFXName()
    {
        return FXSpawner.EnemyDead_One;
    }

}
