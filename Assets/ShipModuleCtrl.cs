using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModuleCtrl : HoangMonoBehaviour
{
    [SerializeField] public List<Transform> modules;
    [SerializeField] protected static ShipModuleCtrl instance;
    [SerializeField] public static ShipModuleCtrl Instance => instance;

    protected override void Awake()
    {
        
            instance = this;
    }

    protected virtual void Start()
    {
        foreach(Transform prefab in transform)
        {
            modules.Add(prefab);
        }

    }
  

}
