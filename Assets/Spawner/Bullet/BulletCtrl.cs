using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static BulletCtrl instance;
    [SerializeField] public static BulletCtrl Instance => instance;
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

    protected virtual void Start()
    {
        this.gameObject.SetActive(true);
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
