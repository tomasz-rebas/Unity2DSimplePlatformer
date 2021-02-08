using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    private string _storedItemName = "";

    public string storedItemName
    {
        get => _storedItemName;
        set
        {
            _storedItemName = value;
        }
    }
}
