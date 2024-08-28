using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtTarget : HoangMonoBehaviour
{
    [SerializeField] protected float rotSpeed = 2f;
    [SerializeField] protected Vector3 targetPosition;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
    }

    protected virtual void LookAtTarget()
    {

        Vector3 diff = this.targetPosition - this.transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(this.transform.parent.rotation, targetEuler, rotSpeed);
        this.transform.parent.rotation = currentEuler;
    }

    protected virtual void SetRotSpeed(float speed)
    {
        this.rotSpeed = speed;
    }

}
