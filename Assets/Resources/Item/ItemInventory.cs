using System;
using UnityEngine;
[Serializable]
public class ItemInventory 
{
    [SerializeField] public ItemSO itemSO;
    [SerializeField] public int itemCount = 0;
    [SerializeField] public int MaxStack = 7;
}
