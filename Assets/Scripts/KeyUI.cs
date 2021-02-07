using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform keyUi;

    void Start ()
    {
        keyUi = gameObject.GetComponent<RectTransform>();
    }

    public void OnDrag (PointerEventData eventData)
    {

    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        
    }

    public void OnEndDrag (PointerEventData eventData)
    {

    }
}
