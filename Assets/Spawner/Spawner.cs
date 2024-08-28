using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Spawner : HoangMonoBehaviour
{

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] public List<Transform> PoolObjs => poolObjs;
    [SerializeField] protected Transform holder;
    [SerializeField] public int spawnCount = 0;
    [SerializeField] protected int resetSpawnCount = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadPreFab();
        
    }

    protected virtual void Start()
    {
        //this.HidePrefab();
    }

    protected virtual void Update()
    {
        this.ResetSpawnCount();
    }


    public virtual Transform Spawn(string objName,Vector3 pos , Quaternion rotation)
    {
        Transform prefab = GetPreFabByName(objName);
        if (prefab == null) Debug.Log("Object not exist in prefab");

        return Spawn(prefab, pos, rotation);
    }

     public virtual Transform Spawn(Transform obj, Vector3 pos, Quaternion rotation)
    {
        Transform prefab = GetObjectFromPool(obj);
        prefab.SetPositionAndRotation(pos, rotation);
        
        return prefab;
    }

   
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
       foreach(Transform obj in this.poolObjs)
        {
            if(prefab.name +"(Clone)" == obj.name)
            {
                
                this.poolObjs.Remove(obj);
                spawnCount++;
                return obj;
            }

        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.SetParent(holder);
        spawnCount++;
        return newPrefab;

    }

    protected virtual void HidePrefab()
    {
        foreach(Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }

    }

    public virtual void Despawn(Transform prefab)
    {
        
        this.poolObjs.Add(prefab);
        
        prefab.gameObject.SetActive(false);
        spawnCount--;

    }

    public virtual bool CanResetSpawnCount()
    {
        return this.spawnCount <= 0;
    }

    public virtual void ResetSpawnCount()
    {
        if(CanResetSpawnCount())
        {
            this.spawnCount = this.resetSpawnCount;
        }

    }


    protected virtual Transform GetPreFabByName(string name)
    {
        foreach(Transform prefab in prefabs)
        {
            if (prefab.name == name) return prefab;
        }
        Debug.Log("Not find prefab by name");
        return GetPreFabInHolder(name);

    }

    protected virtual Transform GetPreFabInHolder(string name)
    {
        foreach(Transform prefab in holder)
        {
            if (prefab.name == name) return prefab;
        }
        
        return null;
    }


    protected virtual void LoadHolder()
    {
        holder = transform.Find("Holder");
    }

    

    protected virtual void LoadPreFab()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }


    }


}
