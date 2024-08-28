using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueImpart : HoangMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadCollider();
    }


    protected virtual void LoadCollider()
    {
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 1f;
        this.sphereCollider.isTrigger = true;
    }

    protected virtual void LoadRigidbody()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.isKinematic = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.name == TorqueCtrl.Instance.Shooter.name || other.CompareTag("Bullet")) return;
       
            
              TorqueCtrl.Instance.DamageSender.SetDamage(2f);
            TorqueCtrl.Instance.DamageSender.Send(other.transform);
            ProjectileSpawner.Instance.Despawn(this.transform.parent);
            this.TorqueHitFX();
        
       
    }



    protected virtual void TorqueHitFX()
    {
        Transform name = AbilityCtrl.Instance.GetComponentInChildren<AbilityTorque>().GetComponent<Transform>();
        string fxName = this.GetTorqueHitFX(name);
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,pos, rot);
        fxOnDead.gameObject.SetActive(true);
        
    }

    protected virtual string GetTorqueHitFX(Transform obj)
    {
        return FXSpawner.Instance.FindFX(obj);
    }

}
