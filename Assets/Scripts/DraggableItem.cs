using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    void Start ()
    {
        itemIcon = item.Find("Icon");
        // Debug.Log("slot1.position = " + itemSlots.slot1.position);
        // Debug.Log("slot2.position = " + itemSlots.slot2.position);

        // Debug.Log("slot1.rect.height = " + itemSlots.slot1.rect.height);
        // Debug.Log("slot2.rect.width = " + itemSlots.slot2.rect.width);
    }

    public void OnDrag (PointerEventData eventData)
    {
        itemUi.position = eventData.position;
        //Debug.Log(eventData.position);
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        showUiItem();
        hideSceneItem();
        Debug.Log("Start dragging.");
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        Debug.Log("OnEndDrag called.");

        if (eventData.hovered.Count > 0)
        {
            bool didFindItemSlot = false;

            foreach (GameObject _go in eventData.hovered)
            {
                Debug.Log("Iterating! " + _go.name);
                if (_go.name == "ItemSlot1" || _go.name == "ItemSlot2")
                {
                    didFindItemSlot = true;
                }
            }

            if (didFindItemSlot)
            {
                Debug.Log("Key dropped in the item slot.");
            }
            else
            {
                showSceneItem();
                hideUiItem();
            }
        }
    }

    private void showUiItem () {itemUi.gameObject.SetActive(true);}
    private void hideUiItem () {itemUi.gameObject.SetActive(false);}
    private void showSceneItem () {itemIcon.gameObject.SetActive(true);}
    private void hideSceneItem () {itemIcon.gameObject.SetActive(false);}
}
