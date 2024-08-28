using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{

    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;

        
        BulletSpawner.Instance.Despawn(this.transform.parent);

    }

    
}
