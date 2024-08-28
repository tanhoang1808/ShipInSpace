using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFly : HoangMonoBehaviour
{
    [SerializeField] protected float objSpeed = 70f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    protected virtual void Update()
    {
        this.Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction * this.objSpeed * Time.deltaTime);
    }

  

    protected virtual void SetSpeed(float speed)
    {
        this.objSpeed = speed;
    }
}
