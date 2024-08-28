using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMoveMent : HoangMonoBehaviour
{
    [Header("Obj movment")]
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float moveSpeed = 0.01f;


    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected abstract void Moving();
    
    protected virtual void SetSpeed(float Speed)
    {
        this.moveSpeed = Speed;
    }

}
