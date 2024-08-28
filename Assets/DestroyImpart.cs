using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyImpart : HoangMonoBehaviour
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
        if (transform.parent.name == DestroyCtrl.Instance.Shooter.name || other.CompareTag("Bullet")) return;

       
        DestroyCtrl.Instance.DamageSender.SetDamage(2f);
        DestroyCtrl.Instance.DamageSender.Send(other.transform);
        ProjectileSpawner.Instance.Despawn(this.transform.parent);
        this.DestroyhitFX();


    }



    protected virtual void DestroyhitFX()
    {
        Transform name = AbilityCtrl.Instance.GetComponentInChildren<AbilityDestroy>().GetComponent<Transform>();
        string fxName = this.GetDestroyhitFX(name);
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, pos, rot);
        fxOnDead.gameObject.SetActive(true);

    }

    protected virtual string GetDestroyhitFX(Transform obj)
    {
        return FXSpawner.Instance.FindFX(obj);
    }

}
