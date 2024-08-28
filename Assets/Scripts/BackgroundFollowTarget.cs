using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowTarget : HoangMonoBehaviour
{
    [SerializeField] protected Transform Target;
    [SerializeField] protected float moveSpeed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Follow();
    }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }
    protected virtual void Follow()
    {
        if (this.Target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.Target.position, Time.fixedDeltaTime * this.moveSpeed);

    }


    protected virtual void LoadTarget()
    {
        Target = GameObject.Find("Destroyer").GetComponent<Transform>();
    }
}
