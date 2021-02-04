using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform item;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void OnDrag (PointerEventData eventData)
    {
        float _x = eventData.position.x;
        float _y = eventData.position.y;

        item.position = cam.ScreenToWorldPoint(new Vector3 (_x, _y, 0f - cam.transform.position.z));
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        Debug.Log("Start dragging.");
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        if (eventData.hovered.Count > 0)
        {
            string _objName = eventData.hovered[eventData.hovered.Count - 1].name;

            if (_objName == "ItemSlot1" || _objName == "ItemSlot2")
            {
                Debug.Log("Key dropped in the item slot.");
            }
        }
    }
}
