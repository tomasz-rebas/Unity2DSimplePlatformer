using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour/*, IDragHandler, IBeginDragHandler, IEndDragHandler*/
{
    private bool _isTaken = false;

    public bool isTaken
    {
        get => _isTaken;
        set
        {
            _isTaken = value;
        }
    }

    // public void OnDrag (PointerEventData eventData) {}
    // public void OnBeginDrag (PointerEventData eventData) {}
    // public void OnEndDrag (PointerEventData eventData) {}
}
