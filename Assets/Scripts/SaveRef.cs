using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRef : MonoBehaviour
{
    public Transform player;
    public Transform keyBlue;
    public Transform keyGreen;
    public RectTransform itemSlots;

    void Start ()
    {
        SaveData data = SaveSystem.LoadGame();

        player.position = new Vector3
        (
            data.position[0],
            data.position[1],
            data.position[2]
        );
    }

    void OnApplicationQuit()
    {
        SaveSystem.SaveGame(this);
    }
}
