using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Ctrl : HoangMonoBehaviour
{
    [SerializeField] protected static Bullet2Ctrl instance;
    [SerializeField] public static Bullet2Ctrl Instance => instance;
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void Awake()
    {

        if (instance != null) return;
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
        if (this.bulletDespawn != null) return;
        bulletDespawn = GetComponentInChildren<BulletDespawn>();
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
