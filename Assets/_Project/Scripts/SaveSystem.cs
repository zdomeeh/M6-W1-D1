using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public Transform player;

    string path;

    void Start()
    {
        path = Application.persistentDataPath + "/playerSave.json"; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L)) 
        {
            Load();
        }
    }

    void Save()
    {
        PlayerData data = new PlayerData();

        data.x = player.position.x;
        data.y = player.position.y;
        data.z = player.position.z;

        data.rotY = player.eulerAngles.y;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);

        Debug.Log("Posizione salvata");
    }

    void Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Vector3 position = new Vector3(data.x, data.y, data.z);

            player.position = position;

            player.rotation = Quaternion.Euler(0, data.rotY, 0);

            Debug.Log("Posizione caricata");
        }
        else
        {
            Debug.Log("Nessun salvataggio trovato");
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public float x;
    public float y;
    public float z;

    public float rotY;
}

