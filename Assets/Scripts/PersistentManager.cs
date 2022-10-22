using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance;
    public string playerName;
    public int bestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int bestScore;
        
    }


    
    public void SavePlayerData()
    {
        PlayerData playerSaveData = new PlayerData();
        playerSaveData.playerName = playerName;
        playerSaveData.bestScore = bestScore;

        string json = JsonUtility.ToJson(playerSaveData);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);

    }

    public void LoadPlayerData()
    {
        string saveFilePath = Application.persistentDataPath + "/save.json";

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            PlayerData playerSaveData = JsonUtility.FromJson<PlayerData>(json);


            playerName = playerSaveData.playerName;
            bestScore = playerSaveData.bestScore;
        }

    }
}
