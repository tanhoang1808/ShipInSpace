using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static TorqueCtrl instance;
    [SerializeField] public static TorqueCtrl Instance => instance;
    [SerializeField] protected TorqueDespawn torqueDespawn;
    public TorqueDespawn TorqueDespawn => torqueDespawn;

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void Awake()
    {
        base.Awake();
        //if (instance != null) Debug.LogWarning("Exceed bullet ctrl");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
        this.LoadDamageSender();
    }

    protected virtual void LoadDespawn()
    {
        if (this.torqueDespawn != null) return;
        torqueDespawn = GetComponentInChildren<TorqueDespawn>();
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
