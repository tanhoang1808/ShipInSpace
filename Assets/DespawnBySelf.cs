using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBySelf : Spawner
{
    [SerializeField] protected float posY = -316f;

    protected override void Update()
    {
        this.DestroySelf();
    }

    protected virtual void DestroySelf()
    {
        if (this.transform.position.y < posY) Despawn(this.transform);
    }

}
