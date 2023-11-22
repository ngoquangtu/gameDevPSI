using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "IngameItem", menuName = "Assets/IngameItem", order = 0)]
public class IngameItem : ScriptableObject {
    [Header("UI")]
    public string itemName;
    public Sprite Icon;
    public string Description;

    [Header("Stats")]
    public ItemCategory category;

    public static class Database
    {
        static List<IngameItem> IngameItems = null;
        public static List<IngameItem> GetIngameItems()
        {
            if (IngameItems != null)
            {
                return IngameItems;
               
            }
            IngameItems = Resources.LoadAll<IngameItem>("IngameItems").ToList();
            return IngameItems;
        }
        public static IngameItem GetItemByName(string ItemName)
            => GetIngameItems().Find(item => item.itemName == ItemName);

    }
public enum ItemCategory 
{
    Harvest,Weapons,Armour,Edible
}
}


