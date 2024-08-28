using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbleItem : HoangMonoBehaviour
{

    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] public EnemyCtrl EnemyCtrl => enemyCtrl;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] public SphereCollider SphereCollider => sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] public Rigidbody Rigidbody => rigidbody;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadEnemyCtrl()
    {
        this.enemyCtrl = Transform.FindObjectOfType<EnemyCtrl>();
    }
    protected virtual void LoadCollider()
    {
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.7f;
    }

    protected virtual void LoadRigidbody()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

}
