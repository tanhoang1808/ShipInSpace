using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLooter : HoangMonoBehaviour
{
    [SerializeField] protected static ItemLooter instance;
    [SerializeField] public static ItemLooter Instance => instance;
    
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] public SphereCollider SphereCollider => sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] public Rigidbody Rigidbody => rigidbody;
    [SerializeField] protected Inventory inventory;
    [SerializeField] public Inventory Inventory => inventory;
    protected override void Awake()
    {
        base.Awake();
        if (ItemLooter.Instance != null) Debug.LogWarning("Exceed PlayerPickUp");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
        this.LoadInventory();
    }

    private void OnTriggerEnter(Collider other)
    {
        PickUpAbleItem pickUpAbleItem = other.GetComponent<PickUpAbleItem>();
        if (pickUpAbleItem == null) return;
        
        ItemCode itemcode = Convert.String2Enum(other.transform.parent.name);
        ItemDropSpawner.Instance.Despawn(other.transform.parent);
        
        this.inventory.AddItem(itemcode,1);
    }

    protected virtual void LoadInventory()
    {
        this.inventory = GetComponentInParent<Inventory>();
    }


    protected virtual void LoadCollider()
    {
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.17f;
    }

    protected virtual void LoadRigidbody()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
}
