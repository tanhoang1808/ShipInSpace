using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : HoangMonoBehaviour
{
    [SerializeField] protected Transform Target;
    [SerializeField] protected float moveSpeed = 2f;
    
    protected virtual void FixedUpdate()
    {
        //this.Follow();
    }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
       
    }
    protected virtual void Follow()
    {
        if (this.Target == null) return;
        Vector3 cameraPos = transform.position;
        Vector3 targetPos = this.Target.position;
        targetPos.x = 0;
        transform.position = Vector3.Lerp(transform.position, this.Target.position, Time.fixedDeltaTime * this.moveSpeed);

    }

   

    protected virtual void LoadTarget()
    {
        Target = GameObject.Find("Ship").GetComponent<Transform>();
    }

}
