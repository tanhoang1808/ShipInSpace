using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : HoangMonoBehaviour
{
    [SerializeField] protected static ShipManager instance;
    [SerializeField] public static ShipManager Instance => instance;
    [SerializeField] protected int respawnCount = 0;
    protected override void Awake()
    {
        base.Awake();
        if (ShipManager.instance != null) Debug.LogWarning("Exceeed enemeyShipManager");
        instance = this;
    }
    [SerializeField] public List<ShipCtrl> ships = new List<ShipCtrl>();
    
    [SerializeField] protected float moveSpeed = 5f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
       

    }
    protected virtual void Start()
    {
        this.LoadShips();
        //Invoke(nameof(SpawnShips), 2f);
    }


    protected virtual void LoadShips()
    {
        Transform shipObj;
        ShipCtrl shipCtrl;
        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Destroyer);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShips(shipCtrl);

        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Striker);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShips(shipCtrl);

        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Thunder);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShips(shipCtrl);


    }

    

    protected virtual void AddShips(ShipCtrl ship)
    {
        ships.Add(ship);
    }

}
