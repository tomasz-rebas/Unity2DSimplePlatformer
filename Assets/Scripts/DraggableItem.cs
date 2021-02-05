using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [System.Serializable] 
    public class ItemSlots
    {
        public RectTransform slot1;
        public RectTransform slot2;
    }

    public RectTransform itemUi;
    public Transform item;
    public ItemSlots itemSlots = new ItemSlots();

    private Transform itemIcon;
    private GraphicRaycaster raycast1;
    private GraphicRaycaster raycast2;

    void Start ()
    {
        itemIcon = item.Find("Icon");
        raycast1 = itemSlots.slot1.gameObject.GetComponent<GraphicRaycaster>();
        raycast2 = itemSlots.slot2.gameObject.GetComponent<GraphicRaycaster>();
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
        List<RaycastResult> results = new List<RaycastResult>();
        raycast1.Raycast(eventData, results);

        bool didHitItemSlot = false;
        Vector3 itemSlotPosition = new Vector3();

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "ItemSlot1")
            {
                didHitItemSlot = true;
                itemSlotPosition = result.gameObject.transform.position;
                break;
            }
        }

        if (didHitItemSlot)
        {
            Debug.Log("Item slot hit!");
            itemUi.position = itemSlotPosition;
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
