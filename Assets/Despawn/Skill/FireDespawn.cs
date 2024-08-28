using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDespawn : DespawnByDistance
{
    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;


        FXSpawner.Instance.Despawn(this.transform.parent);

    }
}
