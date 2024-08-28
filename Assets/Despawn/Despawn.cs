using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : HoangMonoBehaviour
{

    protected virtual void FixedUpdate()
    {
        this.Despawning();
        this.CanDespawn();
    }

   protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;

        Destroy(gameObject);
        
    }
    protected abstract bool CanDespawn();
    

}
