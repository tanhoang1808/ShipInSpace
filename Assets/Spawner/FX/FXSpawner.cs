using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    [SerializeField] protected static FXSpawner instance;
    public static FXSpawner Instance => instance;
    public static string JunkDead_One = "FX_JunkOnDead";
    public static string Bullet_Hit = "FX_Bullet_Hit";
    public static string EnemyDead_One = "FX_DeadEnemy";
    public static string TorqueSkill = "Torque";
    public static string fireSkill = "Fire";
    public static string destroySkill = "Destroy";
    public static string End_TorqueSkill = "FX_Torque_End";
    public List<string> FXName;

    public static string FireSkill = "FireAbility";
    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Excced FXSpawner instance");
            return;
        }
        instance = this;
    }

    public virtual string FindFX(Transform obj)
    {
        foreach(Transform prefab in prefabs)
        {
            if (prefab.name == obj.name) return prefab.name;
        }
        Debug.LogWarning("Cannot find FX name");
        return null;
    }
}
