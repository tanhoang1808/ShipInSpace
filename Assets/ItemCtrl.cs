using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static ItemCtrl instance;
    [SerializeField] public static ItemCtrl Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemCtrl.Instance != null)
        instance = this;
    }
}
