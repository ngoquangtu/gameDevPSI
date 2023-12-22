using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class guiInventory : MonoBehaviour
{
    [SerializeField] private GameObject panelInventory;

    [Header("UI references")]
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image icon;
    [Header("In-game item SO")]
    [SerializeField] List<IngameItem> items;

    int currentIndex;

    private void Start()
    {
        currentIndex = 0;
        items = IngameItem.Database.GetIngameItems();
        if (items != null && items.Count > 0)
        {
            DisplayCurrentIndex(); 
        }
    }

    public void ExitButton()
    {
        panelInventory.SetActive(false);
        Time.timeScale=1;
        Cursor.visible = false; 
    }
    public void InventoryBtn()
    {
        panelInventory.SetActive(true);
        Time.timeScale=0;
        Cursor.visible = true; 
    }

    public void OnNextButton()
    {
        currentIndex++;
        if (currentIndex >= items.Count)
        {
            currentIndex = 0;
        }
        DisplayCurrentIndex(); 
    }

    public void OnPrevButton()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = items.Count - 1;
        }
        DisplayCurrentIndex(); 
    }

    void DisplayCurrentIndex() 
    {
        title.text = items[currentIndex].itemName;
        description.text = $"{items[currentIndex].Description}\nCategory: {items[currentIndex].category}";
        icon.sprite = items[currentIndex].Icon;
    }
}
