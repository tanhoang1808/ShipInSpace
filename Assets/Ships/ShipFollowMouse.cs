using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ObjMoveMent
{
    protected float speed = 0.01f;
    protected float maxRightPos = 8f;
    protected float maxLeftPos = -8f;

    protected float maxUpperPos = 28f;
    protected float maxLowerPos = 0f;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
        this.Moving();
    }

    protected override void LoadComponent()
    {
        this.ResetValue();
        base.LoadComponent();
    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetSpeed(speed);
    }

    protected override void Moving()
    {
        if (this.transform.position.x >= maxRightPos)
        {
            float posX = maxRightPos;
            this.transform.parent.position = new Vector3(posX, transform.position.y);
            
        }
        if(this.transform.position.x <= maxLeftPos)
        {
            float posX = maxLeftPos;
            this.transform.parent.position = new Vector3(posX, transform.position.y);
            
        }
        if (this.transform.position.y>= maxUpperPos)
        {
            float posY = maxUpperPos;
            this.transform.parent.position = new Vector3(transform.position.x, posY);

        }
        if (this.transform.position.y <= maxLowerPos)
        {
            float posY = maxLowerPos;
            this.transform.parent.position = new Vector3(transform.position.x, posY);

        }
        Vector3 movePos = targetPosition;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, movePos, moveSpeed);
        this.transform.parent.position = newPos;
    }
}
