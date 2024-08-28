using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLookAtPlayer : ObjLookAtTarget
{
    [SerializeField] protected float shipRotSpeed = 3f;
    [SerializeField] protected Vector3 playerPosition;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetPlayerPosition();
    }


    protected virtual void GetPlayerPosition()
    {
        playerPosition = ShipCtrl.Instance.transform.position;
        this.targetPosition = playerPosition;
    }

    
    protected override void ResetValue()
    {
        this.SetRotSpeed(shipRotSpeed);
    }

    protected override void SetRotSpeed(float speed)
    {
        this.rotSpeed = shipRotSpeed;

    }

   
    
}
