using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : HoangMonoBehaviour
{
    [SerializeField] protected bool isShoot = false;
    [SerializeField] protected float delayTime = 0.6f;
    [SerializeField] protected float counter = 0f;
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected float maxDistance = 10f;
    [SerializeField] protected float distance;
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.GetbulletCtrl();
    }

    protected virtual void GetbulletCtrl()
    {
        bulletCtrl = Transform.FindObjectOfType<BulletCtrl>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetbulletCtrl();
    }


    protected virtual void FixedUpdate()
    {
        this.IsShooting();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.counter += Time.fixedDeltaTime;

        if (!this.IsShooting()) return;
        if (this.counter < this.delayTime) return;
        this.counter = 0;
        
        Quaternion rot = this.transform.rotation;
        Vector3 pos = this.transform.position;
        Transform bullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, pos, rot);
        BulletCtrl.Instance.SetShooter(transform.parent);
        bullet.gameObject.SetActive(true);
        ShipCtrl.Instance.AudioCtrl.PlayShootSoundFX();
    }

    public virtual void SetDamage(float damage)
    {
        this.damage = damage;
    }

    protected virtual bool IsShooting()
    {
        
        distance = Vector3.Distance(this.transform.parent.position, ShipCtrl.Instance.transform.position);
        return distance <= maxDistance;
       
    }
}
