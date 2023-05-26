using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance; 

    public int bestScore;
    public string bestPlayer;
    public string playerName;

    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayer();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayer;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.bestScore = Persistence.Instance.bestScore;
        data.bestPlayer = Persistence.Instance.bestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Persistence.Instance.bestScore = data.bestScore;
            Persistence.Instance.bestPlayer = data.bestPlayer;
        }
    }
}
