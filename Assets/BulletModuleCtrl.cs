using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModuleCtrl : HoangMonoBehaviour
{
    [SerializeField] public List<Transform> modules;
    [SerializeField] protected static BulletModuleCtrl instance;
    [SerializeField] public static BulletModuleCtrl Instance => instance;

    protected override void Awake()
    {

        instance = this;
    }

    protected virtual void Start()
    {
        if (modules.Count >= 4) return;
        foreach (Transform prefab in transform)
        {
            modules.Add(prefab);
        }

    }
}
