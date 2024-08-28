using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowPlayer : ObjFollowPlayer
{
    protected float ShipSpeed = 0.01f;
    [SerializeField] protected float maxDistance = 1f;
    [SerializeField] protected float distance;
    

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.ResetValue();
    }

    protected override void ResetValue()
    {
        SetSpeed(ShipSpeed);
    }

    protected override void Moving()
    {
        this.distance = Vector3.Distance(this.transform.parent.position, this.targetPosition);
        if (distance < maxDistance) return;
        base.Moving();
    }


}
