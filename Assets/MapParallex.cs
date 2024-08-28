using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapParallex : MonoBehaviour
{
    [SerializeField] protected Vector3 moveDirection = Vector3.down;
    [SerializeField] protected float speed = 2f;

    protected virtual void Update()
    {
        transform.Translate(this.moveDirection * this.speed * Time.deltaTime);
    }
}
