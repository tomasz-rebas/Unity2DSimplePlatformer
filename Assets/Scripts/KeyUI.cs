using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform door;

    private RectTransform keyUi;
    private Vector3 keyUiDefaultPosition;

    void Start ()
    {
        keyUi = gameObject.GetComponent<RectTransform>();
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
            if (hit.collider.name == "DoorBlue")
            {
                Debug.Log("Blue door hit.");
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
}
