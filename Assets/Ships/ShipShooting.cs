using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : HoangMonoBehaviour
{
    [SerializeField] protected bool isShoot = false;
    [SerializeField] protected float delayTime = 0.09f;
    [SerializeField] protected float counter = 0f;
    [SerializeField] protected float damage = 2f;
    [SerializeField] protected List<Transform> points = new List<Transform>();
    [SerializeField] protected List<Transform> tempPoints = new List<Transform>();
    [SerializeField] protected bool isState_One = false;
    [SerializeField] protected bool isState_Two = false;
    [SerializeField] protected bool isState_Third = false;
    protected virtual void Start()
    {
        this.GetBulletPoints();
    }

    protected virtual void GetBulletPoints()
    {
        foreach(Transform point in transform)
        {
            this.points.Add(point);
        }
    }

    

    public virtual bool State_One()
    {
        return ShipCtrl.Instance.level >= 1 && ShipCtrl.Instance.level < 10;
    }

    public virtual bool State_Two()
    {
        return ShipCtrl.Instance.level >= 10 && ShipCtrl.Instance.level < 25;
    }

    public virtual bool State_Third()
    {
        return ShipCtrl.Instance.level >=25;
    }

    //protected virtual void CheckStateBullet()
    //{
        
    //    if(State_One())
    //    {
    //        tempPoints.Clear();
    //        for(int i = 0; i <=points.Count - 3;i++)
    //        {
    //            this.tempPoints.Add(points[i]);
    //        }
    //        isState_One = true;
    //    }
    //    else if(State_Two())
    //    {
    //        tempPoints.Clear();
    //        for (int i = 0; i <= points.Count - 2; i++)
    //        {
    //            this.tempPoints.Add(points[i]);
    //        }
    //    }
    //    else if(State_Third())
    //    {
    //        tempPoints.Clear();
    //        for (int i = 0; i <= points.Count - 1; i++)
    //        {
    //            this.tempPoints.Add(points[i]);
    //        }
    //        return;
    //    }
        
    //}

    protected virtual void Update()
    {
        this.IsShooting();
        //this.CheckStateBullet();
        
    }

    protected virtual void FixedUpdate()
    {
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

        foreach(Transform point in points)
        {

            Transform bullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo, point.position, transform.rotation);
            Bullet2Ctrl.Instance.SetShooter(transform.parent);
            bullet.gameObject.SetActive(true);
        }




        //this.audioCtrl.PlayShootSoundFX();
        AudioCtrl.Instance.PlayShootSoundFX();
    }

    public virtual void SetDamage(float damage)
    {
        this.damage = damage;
    }

    protected virtual bool IsShooting()
    {
        this.isShoot =  InputManager.Instance.OnFiring == 1;
        return this.isShoot;
    }
}
