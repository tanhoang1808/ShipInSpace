using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleFly : HoangMonoBehaviour
{
    [SerializeField] protected Vector3 moveDirection = Vector3.down;
    [SerializeField] protected float moduleSpeed = 2f;

    protected virtual void Update()
    {
        transform.parent.Translate(this.moveDirection * this.moduleSpeed * Time.deltaTime);
    }

}
