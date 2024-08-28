using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected Transform camera;
    [SerializeField] protected float distance;
    [SerializeField] protected float maxDistance = 70f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }
   
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.parent.position, camera.transform.position);

        if (this.distance < maxDistance) return false;

        return true;
       

    }

    protected virtual void LoadCamera()
    {
        if (this.camera != null) return;

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().GetComponent<Transform>();

    }

    protected virtual void setDistance(float distance)
    {
        this.maxDistance = distance;
    }



}
