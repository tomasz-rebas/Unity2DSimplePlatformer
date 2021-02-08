using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerUpHandler
{
    public void OnPointerUp (PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
