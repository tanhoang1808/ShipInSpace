using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : HoangMonoBehaviour
{
    [SerializeField] public int maxSlotInventory = 70;
    [SerializeField] protected List<ItemInventory> items;
    [SerializeField] public  List<ItemInventory> Items => items;
    [SerializeField] public delegate void Notify(ItemCode itemCode);
    [SerializeField] public static event Notify notify;

    //protected override void Awake()
    //{
    //    this.AddItem(ItemCode.Module_1, 7);
    //}

    protected virtual void Update()
    {
        this.GetItemFullStack();
    }

    
    public virtual void AddItem(ItemCode item,int addCount)
    {
        ItemInventory itemExist;
        ItemSO itemSO = GetItemSO(item);
        int addRemain = addCount, newCount, addMore;


        for(int i = 0; i <maxSlotInventory;i++)
        {
            itemExist = this.GetItemNotFullStack(item);
            
            if(itemExist == null)
            {
                itemExist = this.CreateEmptyItem(itemSO);
                this.items.Add(itemExist);
            }
            
            newCount = itemExist.itemCount + addRemain;
            
            if(newCount >= itemExist.MaxStack)
            {
                addMore = itemExist.MaxStack - itemExist.itemCount;
                itemExist.itemCount += addMore;
                addRemain -= addMore;
            }
            else
            {
               
                addRemain -= newCount;
                
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;

               
        }


    }
    protected virtual ItemSO GetItemSO(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemSO));
        foreach (ItemSO profile in profiles)
        {
            if (itemCode != profile.itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemSO itemSO)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemSO = itemSO,
            MaxStack = itemSO.DefaultMaxStack,
            itemCount = 0,

        };
        return itemInventory;
    }

    public virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach(ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemSO.itemCode != itemCode) continue;
            if (itemInventory.itemCount >= itemInventory.MaxStack) continue;
            return itemInventory;
        }
        
        return null;
    }


    public virtual void GetItemFullStack()
    {
        foreach(ItemInventory itemInventory in this.items)
        {
            if(itemInventory.itemCount >= itemInventory.MaxStack)
            {
                notify(itemInventory.itemSO.itemCode);
                itemInventory.itemCount = 0;
            }
        }
    }
}
