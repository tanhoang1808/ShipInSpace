using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;
    public static string bulletOne = "Bullet_1";
    public static string bulletTwo = "Bullet_2";
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Excced Bullet instance");
            return;
        }
        instance = this;
    }

    
}
