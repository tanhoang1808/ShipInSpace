using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : DamageReceiver
{
    [SerializeField] protected float rad = 1f;
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] public ShipCtrl ShipCtrl => shipCtrl;
    protected override void OnDead()
    {
        //this.OnDeadFX();
        

        //EnemyCtrl.Instance.EnemySpawner.Despawn(transform.parent);
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
        this.LoadShipCtrl();
    }
    protected override void ResetRadius(float rad)
    {
        this.sphereCollider.radius = rad;
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        shipCtrl = Transform.FindObjectOfType<ShipCtrl>();
    }

    protected override void setHPMax()
    {
        this.hpMax = shipCtrl.ShipSO.hpMax;
    }



    //protected virtual void OnDeadFX()
    //{
    //    string fxName = this.GetDeadFXName();
    //    Vector3 pos = transform.position;
    //    Quaternion rot = transform.rotation;
    //    Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, pos, rot);

    //    EnemyCtrl.Instance.AudioCtrl.ExplodeSoundFX();
    //    fxOnDead.gameObject.SetActive(true);
    //}

    //protected virtual string GetDeadFXName()
    //{
    //    return FXSpawner.EnemyDead_One;
    //}

}
