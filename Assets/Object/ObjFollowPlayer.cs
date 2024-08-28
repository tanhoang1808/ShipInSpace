using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowPlayer : ObjMoveMent
{
    protected float speed;
    protected override void FixedUpdate()
    {
        this.GetPlayerPosition();
        this.Moving();
        
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.ResetValue();
    }
    protected virtual void GetPlayerPosition()
    {
        
        this.targetPosition = ShipCtrl.Instance.transform.position;
        float randomMovePosX = targetPosition.x + Random.Range(10f, 14f);
        float randomMovePosY = targetPosition.y + Random.Range(10f, 14f);
        Vector3 newTargetPos = new Vector3(randomMovePosX, randomMovePosY);
        this.targetPosition = newTargetPos;
    }

    protected override void Moving()
    {
       
        Vector3 movePos = targetPosition;
       
        //Debug.Log(randomMovePosX);
        //Debug.Log(randomMovePosY);
        //Vector3 randomPos = new Vector3(randomMovePosX, randomMovePosY);
        Vector3 newPos = Vector3.Lerp(transform.parent.position, movePos, moveSpeed);
        this.transform.parent.position = newPos;
    }



}
