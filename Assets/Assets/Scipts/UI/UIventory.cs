using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    public GameObject itemSlotTemplate;
    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        // itemSlotTemplate=itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItem();
    }private void RefreshInventoryItem()
{
    int x = 0;
    int y = 0;
    float itemSlotCellSize = 120f;
    
    foreach (Item item in inventory.GetItemList())
    {
        GameObject itemSlotObject = Instantiate(itemSlotTemplate, itemSlotContainer);
        RectTransform itemSlotRectTransform = itemSlotObject.GetComponent<RectTransform>();
        itemSlotRectTransform.gameObject.SetActive(true);
        itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

        Transform imageTransform = itemSlotRectTransform.Find("image");

        if (imageTransform != null)
        {
            Image image = imageTransform.GetComponent<Image>();
            if (image != null)
            {
                Sprite itemSprite = item.GetSprite();
                if(itemSprite != null)
                {
                    image.sprite=itemSprite;
                }
                 else
                {
                Debug.LogWarning("Sprite is null for item: " + item.name);
                // Optionally, set a default sprite or handle the case appropriately
                }
            }
            else
            {
                Debug.LogError("Image component not found");
            }
           
        }
        else
        {
            Debug.LogError("Child object 'image' not found under item slot template.");
        }
        x++;

        if (x > 4)
        {
            x = 0;
            y++;
        }
    }
}

}
