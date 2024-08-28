using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ObjFly
{
    [SerializeField] protected float junkSpeed = 5f;
    
    protected override void OnEnable()
    {
        this.GetFlyDirection();
    }

    
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.Camera.transform.position;
        Vector3 objPos = transform.parent.position;

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z);
    }

    protected override void ResetValue()
    {
        this.SetSpeed(junkSpeed);
    }
}
