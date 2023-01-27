using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Singleton;

    //for test purposes
    [Header("Test purpose")]
    [SerializeField] List<ItemData> itemsToAdd;

    [Space()]
    [Header("References")]
    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] Transform[] inventorySlots;
    [SerializeField] ItemStatDisplayer displayer; 

    List<ItemData> itemList = new List<ItemData>();    

    private void Start()
    {
        //Singleton
        Singleton = this;

        //add to inventory
        foreach (ItemData item in itemsToAdd)
        {
            itemList.Add(item);
        }

        //this part in game should be represented as some Init() method or inside OnEnable() based on game structure

        //display all items in UI
        for (int i = 0; i < itemList.Count; i++)
        {
            Transform slot = inventorySlots[i];

            if (slot.childCount == 1)
            {
                InventoryItem item = Instantiate(inventoryItemPrefab, slot).GetComponent<InventoryItem>();
                item.itemData = itemList[i];
            }
        }

        DisplayItemStats();
    }

    public void AddToInventory(ItemData item)
    {
        itemList.Add(item);
    }

    public void RemoveFromInventory(ItemData item)
    { 
        itemList.Remove(item);
    }

    // Displayer item stats
    public void DisplayItemStats(ItemData item)
    {
        displayer.selectedImg.SetActive(true);
        displayer.itemName.text = item.displayName;
        displayer.level.text = $"Lv. {item.level}";
        displayer.attack.text = item.attack.ToString();
        displayer.armor.text = item.defence.ToString();
        displayer.energy.text = item.energy.ToString();
        displayer.rand.text = item.rand.ToString();
    }
    public void DisplayItemStats()
    {
        displayer.selectedImg.SetActive(false);
        displayer.itemName.text = "";
        displayer.level.text = $"Lv. ??";
        displayer.attack.text = "--";
        displayer.armor.text = "--";
        displayer.energy.text = "--";
        displayer.rand.text = "--";
    }

}
