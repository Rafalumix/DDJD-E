using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    private static string path = Application.persistentDataPath + ("/player");


    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Game has been saved!");
    }

    public static PlayerData LoadData()
    {
        if (isGameSaved())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close(); 

            return data; 
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null; 
        }
    }

    public static bool isGameSaved()
    {
        return File.Exists(path); 
    }
}
