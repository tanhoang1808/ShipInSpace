using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class DamageReceiver : HoangMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected float hpMax = 2f;
    [SerializeField] public float HpMax => hpMax;
    [SerializeField] protected float hp = 0;
    [SerializeField] public float Hp => hp;
    [SerializeField] protected float radius;
    protected bool isDead = false;


    protected abstract void setHPMax();
    protected abstract void ResetRadius(float rad);
    protected abstract void OnDead();


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        
    }

   protected virtual void Update()
    {
        this.CheckDead();
    }


    protected override void OnEnable()
    {
        this.setHPMax();
        this.Reborn();
        
    }
    public virtual void Deduct(float damage)
    {
        if (IsDead()) return;
        this.hp -= damage;
    }

    protected virtual void Reborn()
    {
        this.hp = hpMax;
        isDead = false;
    }
    public virtual bool IsDead()
    {
        return hp <= 0;
    }

    protected virtual void CheckDead()
    {
        if (!IsDead()) return;
        this.OnDead();

    }

    
}
