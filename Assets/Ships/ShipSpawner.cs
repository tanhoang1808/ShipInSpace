using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : Spawner
{
    [SerializeField] protected static ShipSpawner instance;
    public static ShipSpawner Instance => instance;
    


    protected override void Awake()
    {
        if (ShipSpawner.Instance != null)
        {
            Debug.Log("Excced ShipSpawner instance");

        }
     ShipSpawner.instance = this;
    }


    public virtual Transform Spawn(ShipCode shipCode)
    {
        return this.Spawn(shipCode.ToString(), Vector3.zero, Quaternion.identity);
    }
}
