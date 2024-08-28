using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] protected static InputManager instance;
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos => mouseWorldPos;
    public Camera mainCamera;
    public static InputManager Instance => instance;

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    protected virtual void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    protected virtual void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    protected virtual void FixedUpdate()
    {
        this.GetMouseWorldPos();
        this.GetMouseDown();
    }

    protected virtual void Update()
    {
        PressZ();
        PressV();
        PressX();
        PressZ();
    }

    protected virtual void GetMouseWorldPos()
    {
       Vector3 screenPos = Input.mousePosition;
        screenPos.z = Camera.main.nearClipPlane + 10;
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
        this.mouseWorldPos.z = 0;
        
       
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
       
    }

    public virtual bool PressZ()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }
    public virtual bool PressX()
    {
        return Input.GetKeyDown(KeyCode.X);
    }
    public virtual bool PressC()
    {
        return Input.GetKeyDown(KeyCode.C);
    }
    public virtual bool PressV()
    {
        return Input.GetKeyDown(KeyCode.V);
    }
}


