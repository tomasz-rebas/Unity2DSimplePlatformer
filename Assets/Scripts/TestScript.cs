using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public SaveRef saveRef;

    void Start ()
    {
        SaveSystem.SaveGame(saveRef);
    }

    public void LoadLevel ()
    {
        SaveSystem.LoadGame();
    }
}
