using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public SaveRef saveRef;

    void Start ()
    {
        SaveSystem.LoadGame();
    }

    public void LoadLevel ()
    {
        SaveSystem.LoadGame();
    }
}
