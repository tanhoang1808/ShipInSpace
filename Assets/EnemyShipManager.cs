using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipManager : HoangMonoBehaviour
{
    [SerializeField] protected static EnemyShipManager instance;
    [SerializeField] public static EnemyShipManager Instance => instance;
    [SerializeField] protected int respawnCount = 0;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Exceeed enemeyShipManager");
        instance = this;
    }
    [SerializeField] public List<EnemyCtrl> ships = new List<EnemyCtrl>();
    [SerializeField] public List<EnemyCode> enemyCodes = new List<EnemyCode>();
    [SerializeField] public List<Transform> standPoints = new List<Transform>();
    [SerializeField] public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] protected float moveSpeed = 5f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoints();
        this.LoadStandPoints();
    }
    protected virtual void Start()
    {
        this.LoadShips();
        //Invoke(nameof(SpawnShips), 2f);
        //this.SpawnShips();
    }


    protected virtual void LoadShips()
    {
        Transform enemyObj;
        EnemyCtrl enemyCtrl;
        enemyObj = EnemySpawner.Instance.Spawn(EnemyCode.Fighter);
        enemyCtrl = enemyObj.GetComponent<EnemyCtrl>();
        this.AddShips(enemyCtrl);

        enemyObj = EnemySpawner.Instance.Spawn(EnemyCode.Bomber);
        enemyCtrl = enemyObj.GetComponent<EnemyCtrl>();
        this.AddShips(enemyCtrl);

        enemyObj = EnemySpawner.Instance.Spawn(EnemyCode.Assult);
        enemyCtrl = enemyObj.GetComponent<EnemyCtrl>();
        this.AddShips(enemyCtrl);

        enemyObj = EnemySpawner.Instance.Spawn(EnemyCode.Tanker);
        enemyCtrl = enemyObj.GetComponent<EnemyCtrl>();
        this.AddShips(enemyCtrl);

        enemyObj = EnemySpawner.Instance.Spawn(EnemyCode.Destructor);
        enemyCtrl = enemyObj.GetComponent<EnemyCtrl>();
        this.AddShips(enemyCtrl);
    }

   

    protected virtual void AddShips(EnemyCtrl enemy)
    {
        ships.Add(enemy);
    }

    protected virtual void FixedUpdate()
    {
        float spawnCount = EnemySpawner.Instance.spawnCount;

        if(spawnCount == respawnCount)
        {
            //this.SpawnShips();
            //EnemySpawner.Instance.spawnCount += 5;
            for(int i = 0; i < ships.Count;i++)
            {
                Transform obj = EnemySpawner.Instance.Spawn(ships[i].transform.name, spawnPoints[i].position, Quaternion.identity);
                obj.gameObject.SetActive(true);
            }
        }

    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints.Count >= 5) return;
        Transform points = Transform.FindObjectOfType<EnemySpawnPoint>().GetComponent<Transform>();

        foreach (Transform point in points)
        {
            this.spawnPoints.Add(point);
        }
    }

    protected virtual void LoadStandPoints()
    {
        if (standPoints.Count >= 5) return;
        Transform points = Transform.FindObjectOfType<EnemyStandPoint>().GetComponent<Transform>();

        foreach (Transform point in points)
        {
            this.standPoints.Add(point);
        }
    }

    protected virtual void SpawnShips()
    {
        int index = 0;
        foreach(EnemyCtrl ship in ships)
        {
            SpawnShips(ship, index);
            index++;
        }

        
    }

    protected virtual void SpawnShips(EnemyCtrl ship,int index)
    {
        Transform point = spawnPoints[index];
        ship.transform.position = point.position;
        ship.gameObject.SetActive(true);

    }

    

    public virtual int GetShip(EnemyCtrl currentShip)
    {
        
        for(int i = 0; i <ships.Count;i++)
        {
            if (ships[i].name == currentShip.name) return i;
        }
        return 4;
    }

}
