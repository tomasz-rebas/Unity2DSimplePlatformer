using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnDrag (PointerEventData eventData)
    {
        // TODO
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        Debug.Log("Down");
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        Debug.Log("Up");
    }
}
