using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float[] position;
    public List<string> inventory = new List<string>();
    public bool doorBlueOpen;
    public bool doorGreenOpen;

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

        Transform doorBlueDetectionArea = saveRef.doorBlue.parent.Find("DetectionArea");
        Transform doorGreenDetectionArea = saveRef.doorGreen.parent.Find("DetectionArea");

        doorBlueOpen = doorBlueDetectionArea.gameObject.activeSelf;
        doorGreenOpen = doorGreenDetectionArea.gameObject.activeSelf;
    }
}
