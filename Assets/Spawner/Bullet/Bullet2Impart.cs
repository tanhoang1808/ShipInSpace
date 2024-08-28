using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Impart : HoangMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected float center_y;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadCollider();
    }



    protected virtual void LoadCollider()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.9f;
        sphereCollider.center = new Vector3(0, 0.3f, 0);
    }
    protected virtual void LoadRigidbody()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        rigidbody.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == Bullet2Ctrl.Instance.Shooter.name) return;
        else if (other.CompareTag("Bullet")) return;
        Bullet2Ctrl.Instance.DamageSender.Send(other.transform);
        this.BulleTwotHitFX(other.transform);
        BulletSpawner.Instance.Despawn(this.transform.parent);
    }

    protected virtual void BulleTwotHitFX(Transform obj)
    {
        string fxName = this.GetBulleTwotHitFX();
        Vector3 pos = obj.position - new Vector3(0, 0.6f);
        Quaternion rot = obj.rotation;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, pos, rot);
        //FX button_hit
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetBulleTwotHitFX()
    {
        return FXSpawner.Bullet_Hit;
    }

}
