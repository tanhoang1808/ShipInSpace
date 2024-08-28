using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLookAtMouse : ObjLookAtTarget
{
    [SerializeField] protected float speed = 0.5f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetMousePosition();
    }

    protected virtual void GetMousePosition()
    
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;

    }

    protected override void SetRotSpeed(float rotSpeed)
    {
        base.SetRotSpeed(speed);
    }
}

