using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;
    void Start()
    {
        itemList = new List<Item>();
        AddItem(new Item{itemType=Item.ItemType.Sword,amount=1});
        AddItem(new Item{itemType=Item.ItemType.HealthPotion,amount=1});
        AddItem(new Item{itemType=Item.ItemType.ManaPotion,amount=1});

    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
