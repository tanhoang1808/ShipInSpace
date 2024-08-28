using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static GameCtrl instance;
    [SerializeField] public static GameCtrl Instance => instance;

    [SerializeField] protected Camera camera;
    public Camera Camera => camera;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Exceed GameCtrl");
        instance = this;
    }


    protected virtual void LoadCamera()
    {
        camera = FindObjectOfType<Camera>();
    }


}
