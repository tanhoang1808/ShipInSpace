using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static EnemyCtrl instance;
    public static EnemyCtrl Instance => instance;
    

    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl ShipCtrl => shipCtrl;

    [SerializeField] protected AudioCtrl audioCtrl;
    public AudioCtrl AudioCtrl => audioCtrl;

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;
    [SerializeField] public int maxHP;

    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    [SerializeField] public List<ItemSO> droplist;

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            instance = this; // Destroy the duplicate instance
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShipCtrl();
        this.LoadEnemySpawner();
        this.LoadAudioCtrl();
        this.LoadEnemySO();
        
    }

    

    protected virtual void LoadEnemySpawner()
    {
        this.enemySpawner = GetComponentInParent<EnemySpawner>();
    }

    protected virtual void LoadEnemySO()
    {
        string resPath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resPath);
        maxHP = this.enemySO.hpMax;
    }
    protected virtual void LoadAudioCtrl()
    {
        audioCtrl = FindObjectOfType<AudioCtrl>();
    }


    protected virtual void LoadShipCtrl()
    {
        shipCtrl = FindObjectOfType<ShipCtrl>();
    }

    
}
