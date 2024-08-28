using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static FireCtrl instance;
    [SerializeField] public static FireCtrl Instance => instance;
    [SerializeField] protected FireDespawn fireDespawn ;
    public FireDespawn FireDespawn => fireDespawn;

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void Awake()
    {
        base.Awake();
        //if (instance != null) Debug.LogWarning("Exceed Firectrl");
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
        if (this.fireDespawn != null) return;
        fireDespawn = GetComponentInChildren<FireDespawn>();
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
