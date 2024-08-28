using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : HoangMonoBehaviour
{
    [SerializeField] protected static JunkCtrl instance;
    public static JunkCtrl Instance => instance;
    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO => junkSO;
    [SerializeField] protected Transform prefab;

    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl ShipCtrl => shipCtrl;

    [SerializeField] protected AudioCtrl audioCtrl;
    public AudioCtrl AudioCtrl => audioCtrl;

    //[SerializeField] protected SpawnPoint spawnPoint;
    //public SpawnPoint SpawnPoint => spawnPoint;

    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;
    


    protected override void Awake()
    {
        if (JunkCtrl.instance != null) return;
        instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //this.LoadSpawnPoint();
        this.LoadShipCtrl();
        this.LoadJunkSpawner();
        this.LoadAudioCtrl();
        this.LoadJunkSO();
    }
    
    protected virtual void LoadJunkSO()
    {
        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);

    }

    

    protected virtual void LoadAudioCtrl()
    {
        audioCtrl = FindObjectOfType<AudioCtrl>();
    }

    //protected virtual void LoadSpawnPoint()
    ////{
    ////    spawnPoint = Transform.FindObjectOfType<SpawnPoint>();
    //}

    protected virtual void LoadShipCtrl()
    {
        shipCtrl = FindObjectOfType<ShipCtrl>();
    }

    protected virtual void LoadJunkSpawner()
    {
        junkSpawner = GetComponentInParent<JunkSpawner>();
    }

    
}
