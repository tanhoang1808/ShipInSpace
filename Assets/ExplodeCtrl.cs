using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static ExplodeCtrl instance;
    [SerializeField] public static ExplodeCtrl Instance => instance;
    

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Exceed ExplodeCtrl");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
       
        this.LoadDamageSender();
    }

   
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        damageSender = GetComponentInChildren<DamageSender>();
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
