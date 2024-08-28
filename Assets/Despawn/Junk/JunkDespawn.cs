using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    
    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;

       
        JunkSpawner.Instance.Despawn(this.transform.parent);

    }

    
    
}
