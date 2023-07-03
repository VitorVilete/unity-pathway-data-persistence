using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public string CurrentPlayerName;
    public string BestPlayerName;
    public int BestPlayerScore;

    private void Awake()
    {
        //Preventing the existence of more than 1 MainManager GameObject
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadGameData();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string CurrentPlayerName;
        public string BestPlayerName;
        public int BestPlayerScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.CurrentPlayerName = CurrentPlayerName;
        data.BestPlayerName = BestPlayerName;
        data.BestPlayerScore = BestPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentPlayerName = data.CurrentPlayerName;
            BestPlayerName = data.BestPlayerName;
            BestPlayerScore = data.BestPlayerScore;
        }
    }

    public void OnApplicationQuit()
    {
        Instance.SaveGameData();
    }
}
