using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item",menuName = "ItemSO/Item")]
public class ItemSO :ScriptableObject
{
    [SerializeField] public ItemCode itemCode;
    [SerializeField] public ItemType itemType;
    [SerializeField] public ItemRare itemRare;
    //[SerializeField] public Sprite sprite;
    [SerializeField] public int DefaultMaxStack = 7;
}
