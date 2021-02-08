using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/save.dat";
    //private static string path = "D:/desktop/save.dat";

    public static void SaveGame (SaveRef saveRef)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(saveRef);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadGame ()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found.");
            return null;
        }

    }
}
