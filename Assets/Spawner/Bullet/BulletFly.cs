using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ObjFly
{
    [SerializeField] protected float bulletSpeed = 50f;

   
    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetSpeed(bulletSpeed);
    }
}
