using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static AbilityCtrl instance;
    [SerializeField] public static AbilityCtrl Instance => instance;

    [SerializeField] protected InputManager inputManager;
    [SerializeField] public InputManager InputManager => inputManager;

    [SerializeField] protected AbilityTorque abilityTorque;
    [SerializeField] public AbilityTorque AbilityTorque => abilityTorque;

    [SerializeField] protected AbilityFire abilityFire;
    [SerializeField] public AbilityFire AbilityFire => abilityFire;

    [SerializeField] protected AbilityDestroy abilityDestroy;
    [SerializeField] public AbilityDestroy AbilityDestroy => abilityDestroy;

    [SerializeField] protected ProjectileSpawner projectileSpawner;
    [SerializeField] public ProjectileSpawner ProjectileSpawner => projectileSpawner;
    [SerializeField] public ShipCtrl shipCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (AbilityCtrl.instance != null) Debug.LogWarning("Exceed AbilityCtrl");
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInputManager();
        this.LoadAbilityTorque();
        this.LoadAbilityDestroy();
        this.LoadAbilityFire();
        this.LoadProjectileSpawner();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        this.shipCtrl = GetComponentInParent<ShipCtrl>();
    }

    protected virtual void LoadInputManager()
    {
        this.inputManager = Transform.FindObjectOfType<InputManager>();
    }

    protected virtual void LoadAbilityTorque()
    {
        this.abilityTorque = GetComponentInChildren<AbilityTorque>();
    }
    protected virtual void LoadAbilityFire()
    {
        this.abilityFire = GetComponentInChildren<AbilityFire>();
    }
    protected virtual void LoadAbilityDestroy()
    {
        this.abilityDestroy = GetComponentInChildren<AbilityDestroy>();
    }

    protected virtual void LoadProjectileSpawner()
    {
        this.projectileSpawner = Transform.FindObjectOfType<ProjectileSpawner>();
    }


}
