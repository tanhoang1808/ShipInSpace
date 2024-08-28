using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireImpart : HoangMonoBehaviour
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
        this.sphereCollider.radius = 0.8f;
        this.sphereCollider.isTrigger = true;
    }

    protected virtual void LoadRigidbody()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.isKinematic = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.name == FireCtrl.Instance.Shooter.name || other.CompareTag("Bullet")) return;

        
        FireCtrl.Instance.DamageSender.SetDamage(2f);
        FireCtrl.Instance.DamageSender.Send(other.transform);
        ProjectileSpawner.Instance.Despawn(this.transform.parent);
        this.FireHitFX();


    }



    protected virtual void FireHitFX()
    {
        Transform name = AbilityCtrl.Instance.GetComponentInChildren<AbilityFire>().GetComponent<Transform>();
        string fxName = this.GetFireHitFX(name);
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, pos, rot);
        fxOnDead.gameObject.SetActive(true);

    }

    protected virtual string GetFireHitFX(Transform obj)
    {
        return FXSpawner.Instance.FindFX(obj);
    }

}
