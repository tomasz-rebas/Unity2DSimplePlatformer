using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;

    public Transform keyBlue;
    public Transform keyGreen;

    public RectTransform keyBlueUi;
    public RectTransform keyGreenUi;

    public Transform doorBlue;
    public Transform doorGreen;

    public RectTransform itemSlots;

    private Transform doorBlueDetectionArea;
    private Transform doorGreenDetectionArea;

    void Start ()
    {
        SaveData data = SaveSystem.LoadGame();

        #region Player position

        player.position = new Vector3
        (
            data.position[0],
            data.position[1],
            data.position[2]
        );

        #endregion

        #region Doors

        doorBlueDetectionArea = doorBlue.parent.Find("DetectionArea");
        doorGreenDetectionArea = doorGreen.parent.Find("DetectionArea");

        if (data.doorBlueOpen)
        {
            doorBlueDetectionArea.gameObject.SetActive(true);
            keyBlue.gameObject.SetActive(false);
        }

        if (data.doorGreenOpen)
        {
            doorGreenDetectionArea.gameObject.SetActive(true);
            keyGreen.gameObject.SetActive(false);
        }

        #endregion

        #region Inventory

        int _i = 0;
        foreach (RectTransform slot in itemSlots)
        {
            if (data.inventory[_i] == "KeyBlue")
            {
                keyBlue.gameObject.SetActive(false);
                keyBlueUi.gameObject.SetActive(true);
                keyBlueUi.position = slot.position;
            }
            if (data.inventory[_i] == "KeyGreen")
            {
                keyGreen.gameObject.SetActive(false);
                keyGreenUi.gameObject.SetActive(true);
                keyGreenUi.position = slot.position;
            }
            _i++;
        }

        #endregion
    }

    void OnApplicationQuit ()
    {
        SaveSystem.SaveGame(this);
    }

    public void ResetGame ()
    {
        player.position = new Vector3 (0, -1, 0);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);

        keyBlue.position = new Vector3 (-4, -2.3f, 0);
        keyGreen.position = new Vector3 (30, -2.3f, 0);

        keyBlue.gameObject.SetActive(true);
        keyGreen.gameObject.SetActive(true);

        keyBlue.Find("Icon").gameObject.SetActive(true);
        keyGreen.Find("Icon").gameObject.SetActive(true);

        keyBlueUi.gameObject.SetActive(false);
        keyGreenUi.gameObject.SetActive(false);

        doorBlueDetectionArea.gameObject.SetActive(false);
        doorGreenDetectionArea.gameObject.SetActive(false);
        
        SaveSystem.SaveGame(this);
    }
}
