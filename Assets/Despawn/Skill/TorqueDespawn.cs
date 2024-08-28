using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueDespawn : DespawnByDistance
{
    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;


        ProjectileSpawner.Instance.Despawn(this.transform.parent);

    }
}
