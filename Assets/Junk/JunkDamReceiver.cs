using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamReceiver : DamageReceiver
{
    protected float rad = 0.76f;
    protected override void OnDead()
    {
        this.OnDeadFX();
        
        JunkCtrl.Instance.JunkSpawner.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetRadius(rad);
        this.setHPMax();
    }
    protected override void ResetRadius(float rad)
    {
        this.sphereCollider.radius = rad;
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetDeadFXName();
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, pos, rot);
        JunkCtrl.Instance.AudioCtrl.ExplodeSoundFX();
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetDeadFXName()
    {
        return FXSpawner.JunkDead_One;
    }

    protected override void setHPMax()
    {
        this.hpMax = JunkCtrl.Instance.JunkSO.hpMax;
        
    }


}
