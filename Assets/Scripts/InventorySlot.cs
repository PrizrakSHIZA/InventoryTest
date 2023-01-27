using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public static InventorySlot selectedSlot;

    [SerializeField] GameObject selectedImg;

    public void Select()
    {
        if (selectedSlot != null && selectedSlot != this)
        {
            selectedSlot.Unselect();
            selectedSlot = this;
        }

        if (selectedImg.activeSelf)
        {
            Unselect();
            return;
        }
        else
        {
            selectedSlot = this;
            selectedImg.SetActive(true);
        }
    }

    public void Unselect()
    {
        selectedSlot = null;
        selectedImg.SetActive(false);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 1)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (inventoryItem != null)
            { 
                inventoryItem.parentAfterDrag = transform;
                if (inventoryItem.itemData.equiped)
                { 
                    inventoryItem.itemData.equiped = false;
                    EquipmentSystem.Singleton.Unequip(inventoryItem.itemData);
                }
            }
        }
    }
}
