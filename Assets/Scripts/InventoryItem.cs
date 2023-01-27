using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public ItemData itemData;

    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        InitializeItem(itemData);
    }

    void InitializeItem(ItemData item)
    {
        image.sprite = item.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        InventorySlot.selectedSlot?.Unselect();
        InventorySystem.Singleton.DisplayItemStats();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<InventorySlot>().Select();
        InventorySystem.Singleton.DisplayItemStats(itemData);
    }
}
