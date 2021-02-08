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

    public SaveData (GameManager gameManager)
    {
        position = new float[3];

        position[0] = gameManager.player.transform.position.x;
        position[1] = gameManager.player.transform.position.y;
        position[2] = gameManager.player.transform.position.z;

        foreach (RectTransform slot in gameManager.itemSlots)
        {
            inventory.Add(slot.GetComponent<ItemSlot>().storedItemName);
        }

        Transform doorBlueDetectionArea = gameManager.doorBlue.parent.Find("DetectionArea");
        Transform doorGreenDetectionArea = gameManager.doorGreen.parent.Find("DetectionArea");

        doorBlueOpen = doorBlueDetectionArea.gameObject.activeSelf;
        doorGreenOpen = doorGreenDetectionArea.gameObject.activeSelf;
    }
}
