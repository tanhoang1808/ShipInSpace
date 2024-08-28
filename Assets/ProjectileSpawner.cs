using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    [SerializeField] protected static ProjectileSpawner instance;
    public static ProjectileSpawner Instance => instance;
    
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Excced ProjectileSpawner instance");

        }
        ProjectileSpawner.instance = this;
    }

    

    
}
