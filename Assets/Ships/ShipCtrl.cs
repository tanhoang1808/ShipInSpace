using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : HoangMonoBehaviour
{
    protected static ShipCtrl instance;
    [SerializeField] public static ShipCtrl Instance => instance;

    [SerializeField] protected AudioCtrl audioCtrl;
    public AudioCtrl AudioCtrl => audioCtrl;

    [SerializeField] protected ShipModuleCtrl moduleCtrl;
    public ShipModuleCtrl ModuleCtrl => moduleCtrl;

    [SerializeField] protected Bullet2Ctrl bullet2Ctrl;
    public Bullet2Ctrl BulletCtrl => bullet2Ctrl;

    [SerializeField] protected AbilityCtrl abilityCtrl;
    public AbilityCtrl AbilityCtrl => abilityCtrl;

    [SerializeField] protected ShipSO shipSO;
    [SerializeField] public ShipSO ShipSO => shipSO;


    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] public DamageReceiver DamageReceiver => damageReceiver;

    [Header("Player Status")]
    [SerializeField] public int playerExp;
    [SerializeField] public int level;
    
    protected override void Awake()
    {
        if (ShipCtrl.instance != null) Debug.LogWarning("Exceed ShipCtrl");
            instance = this;
        
    }

    protected virtual void LoadPlayerStatus()
    {
        this.playerExp = shipSO.exp;
        this.level = shipSO.Level;
    }
    protected virtual void LoadDamageReceiver()
    {
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
    }

    protected virtual void Update()
    {
        this.playerExp = shipSO.exp;
        this.level = shipSO.Level;
    }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioCtrl();
        this.LoadBulletCtrl();
        this.LoadAbilityCtrl();
        this.LoadShipSO();
        this.LoadPlayerStatus();
        this.LoadDamageReceiver();
        this.LoadModuleCtrl();
    }

    protected virtual void LoadModuleCtrl()
    {
        this.moduleCtrl = GetComponentInChildren<ShipModuleCtrl>();
    }

    protected virtual void LoadAudioCtrl()
    {
        audioCtrl = FindObjectOfType<AudioCtrl>();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bullet2Ctrl != null) return;
        bullet2Ctrl = FindObjectOfType<Bullet2Ctrl>();
    }

    protected virtual void LoadAbilityCtrl()
    {
        if (abilityCtrl != null) return;
        abilityCtrl = FindObjectOfType<AbilityCtrl>();
    }

    protected virtual void LoadShipSO()
    {
        string resPath = "Ship/" + transform.name;
        this.shipSO = Resources.Load<ShipSO>(resPath);
        
    }

}
