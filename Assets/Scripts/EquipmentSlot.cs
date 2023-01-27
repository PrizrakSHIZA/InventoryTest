using UnityEngine.EventSystems;

public class EquipmentSlot : InventorySlot
{
    public EquipmentType type;

    public override void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 2)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (inventoryItem.itemData.type != type) return;
            if (inventoryItem != null)
            { 
                inventoryItem.parentAfterDrag = transform;
                if (!inventoryItem.itemData.equiped)
                { 
                    inventoryItem.itemData.equiped = true;
                    EquipmentSystem.Singleton.Equip(inventoryItem.itemData);
                }

            }
        }
    }
}
