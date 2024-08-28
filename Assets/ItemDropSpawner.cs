using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    [SerializeField] protected static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;



    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Excced ItemDropSpawner instance");

        }
        ItemDropSpawner.instance = this;
    }

   

    public virtual Transform Drop(ItemSO item,Vector3 pos ,Quaternion rot)
    {
        Transform prefab = this.Spawn(item.itemCode.ToString(), pos, rot);
        prefab.name = prefab.name.Replace("(Clone)", "");
        if (prefab == null) return null;
        return prefab;

    }

}
