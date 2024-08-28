using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ship", menuName = "ShipSO/Ship")]
public class ShipSO : ScriptableObject
{
    [SerializeField] public int hpMax = 3;
    [SerializeField] protected string shipName = "ship";
    [SerializeField] protected ShipCode shipCode;
    [SerializeField] public int Level = 1;
    
    [SerializeField] public int  exp = 0;
}
