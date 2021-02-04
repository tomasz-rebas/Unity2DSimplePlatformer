using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnDrag (PointerEventData eventData) {}

    public void OnBeginDrag (PointerEventData eventData) {}

    public void OnEndDrag (PointerEventData eventData)
    {
        if (eventData.hovered.Count > 0)
        {
            string _objName = eventData.hovered[eventData.hovered.Count - 1].name;
            if (_objName == "DoorBlue" || _objName == "DoorGreen")
            {
                Debug.Log("Key used to open the door.");
            }
        }
    }
}
