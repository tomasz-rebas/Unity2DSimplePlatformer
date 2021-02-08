using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float[] position;
    public List<string> inventory = new List<string>();

    public SaveData (SaveRef saveRef)
    {
        position = new float[3];

        position[0] = saveRef.player.transform.position.x;
        position[1] = saveRef.player.transform.position.y;
        position[2] = saveRef.player.transform.position.z;

        foreach (RectTransform slot in saveRef.itemSlots)
        {
            inventory.Add(slot.GetComponent<ItemSlot>().storedItemName);
        }
    }
}
