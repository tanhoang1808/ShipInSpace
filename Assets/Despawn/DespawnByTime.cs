using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float maxTime = 1.5f;
    [SerializeField] protected float timer = 0;

    protected override void FixedUpdate()
    {
        if(CanDespawn())
        {
            FXSpawner.Instance.Despawn(transform);
        }
        
    }

    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;

        if(timer >= maxTime)
        {
            timer = 0;
            return true;
        }
        return false;
    }

   
}
