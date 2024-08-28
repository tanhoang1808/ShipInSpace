using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : HoangMonoBehaviour
{
    [SerializeField] protected  BulletCtrl bulletCtrl;
    public  BulletCtrl BulletCtrl => bulletCtrl;

   

    protected override void LoadComponent()
    {
       
        this.LoadBulletCtrl();
        //this.LoadBullet2Ctrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = this.transform.parent.GetComponent<BulletCtrl>();
    }

    
}
