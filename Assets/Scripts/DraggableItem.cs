using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform itemSlots;
    public RectTransform itemUi;

    private Transform item;
    private Transform itemIcon;
    private List<GraphicRaycaster> raycasters = new List<GraphicRaycaster>();

    void Start ()
    {
        item = gameObject.GetComponent<Transform>();
        itemIcon = item.Find("Icon");

        foreach (RectTransform child in itemSlots)
        {
            raycasters.Add(child.GetComponent<GraphicRaycaster>());
        }
    }

    public void OnDrag (PointerEventData eventData)
    {
        itemUi.position = eventData.position;
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        showUiItem();
        hideSceneItem();
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        bool didHitItemSlot = false;
        Vector3 itemSlotPosition = new Vector3();

        foreach (GraphicRaycaster raycaster in raycasters)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "ItemSlot")
                {
                    ItemSlot _slot = result.gameObject.GetComponent<ItemSlot>();

                    if (_slot.storedItemName == "")
                    {
                        didHitItemSlot = true;
                        itemSlotPosition = result.gameObject.transform.position;
                        _slot.storedItemName = item.name;
                        break;
                    }
                }
            }

            if (didHitItemSlot)
            {
                break;
            }
        }

        if (didHitItemSlot)
        {
            itemUi.position = itemSlotPosition;
            item.gameObject.SetActive(false);
        }
        else
        {
            showSceneItem();
            hideUiItem();
        }
    }

    private void showUiItem () {itemUi.gameObject.SetActive(true);}
    private void hideUiItem () {itemUi.gameObject.SetActive(false);}
    private void showSceneItem () {itemIcon.gameObject.SetActive(true);}
    private void hideSceneItem () {itemIcon.gameObject.SetActive(false);}
}
