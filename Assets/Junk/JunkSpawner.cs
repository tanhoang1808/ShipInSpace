using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    [SerializeField] protected static JunkSpawner instance;
    public static JunkSpawner Instance => instance;
    public static string AsteroidOne = "Asteroid_1";
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Excced Junkspawner instance");
            return;
        }
        instance = this;
    }

    
}
