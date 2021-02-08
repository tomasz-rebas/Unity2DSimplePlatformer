using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform door;
    public Transform key;

    private RectTransform keyUi;
    private Vector3 keyUiDefaultPosition;
    private Transform doorDetectionArea;
    private RectTransform itemSlots;

    void Start ()
    {
        keyUi = gameObject.GetComponent<RectTransform>();
        doorDetectionArea = door.parent.Find("DetectionArea");
        itemSlots = GameObject.Find("ItemSlots").GetComponent<RectTransform>();
    }

    public void OnDrag (PointerEventData eventData)
    {
        keyUi.position = eventData.position;
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        keyUiDefaultPosition = keyUi.position;
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.name == door.name)
            {
                ActivateDoor();
                keyUi.gameObject.SetActive(false);
                RemoveItemFromInventory();
            }
            else
            {
                keyUi.position = keyUiDefaultPosition;
            }
        }
        else
        {
            keyUi.position = keyUiDefaultPosition;
        }
    }

    private void RemoveItemFromInventory ()
    {
        foreach (RectTransform slot in itemSlots)
        {
            if (slot.GetComponent<ItemSlot>().storedItemName == key.name)
            {
                slot.GetComponent<ItemSlot>().storedItemName = "";
            }
        }
    }

    private void ActivateDoor ()
    {
        doorDetectionArea.gameObject.SetActive(true);
    }
}
